


import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.equalTo;

import java.util.HashMap;

import org.testng.annotations.Test;

import io.restassured.http.ContentType;


public class GraphQLExample {
	

    String queryString1 = """
                {
                  
                  country(code: "GB") {
                    name
                    native
                    capital
                    emoji
                    currency
                    languages {
                      code
                      name
                    }
                  }
                }

                """;



@Test
    public void useHardCodedValuesInQuery_checkCountryInfo() {

        HashMap<String, Object> graphQlQuery = new HashMap<>();
        graphQlQuery.put("query", queryString1);

        given().
            contentType(ContentType.JSON).
            body(graphQlQuery).
        when().
            post("https://countries.trevorblades.com/graphql").
        then().
            assertThat().
            statusCode(200).log().all().
        and().
           body("data.country.name", equalTo("United Kingdom"));
    } 


    

}
