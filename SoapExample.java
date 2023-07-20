import static io.restassured.RestAssured.*;
import static org.hamcrest.Matchers.*;
import org.testng.annotations.Test;

import io.restassured.RestAssured;
import io.restassured.path.xml.XmlPath;
import io.restassured.response.Response;


public class SoapExample {
	@Test
	public void postMethod() throws Exception {
	        
		
		String payload = "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:web=\"http://www.dataaccess.com/webservicesserver/\">\r\n" + 
				"   <soap:Header/>\r\n" + 
				"   <soap:Body>\r\n" + 
				"      <web:NumberToDollars>\r\n" + 
				"         <web:dNum>3</web:dNum>\r\n" + 
				"      </web:NumberToDollars>\r\n" + 
				"   </soap:Body>\r\n" + 
				"</soap:Envelope>";
		
		
		RestAssured.baseURI="https://www.dataaccess.com/webservicesserver/numberconversion.wso";
	         
	         Response response=given()
	                .header("Content-Type", "application/soap+xml;charset=UTF-8")
	                .header("Accept-Encoding", "gzip,deflate")
	                .and()
	                .body(payload)
	         .when()
	            .post()
	         .then()
	                .statusCode(200)
	                .and()
	                .log().all()
	                .extract().response();
	         
	       // XmlPath jsXpath= new XmlPath(response.asString());//Converting string into xml path to assert
	        //String rate=jsXpath.getString("GetConversionRateResult");
	       // System.out.println("rate returned is: " +  rate);
		
	}

}