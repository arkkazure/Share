package com.restassured.tests;

import static io.restassured.RestAssured.get;
import static io.restassured.RestAssured.given;

import java.util.List;

import org.testng.annotations.Test;

import com.github.tomakehurst.wiremock.WireMockServer;

import io.restassured.path.xml.element.Node;
import io.restassured.response.Response;

public class E19_XmlResponseBodyTraverse {

	// @Test
	public void testXmlResponse() {
		WireMockServer wireMockServer = new WireMockServer(2020); // No-args constructor will start on port 8080, no
																	// HTTPS

		wireMockServer.start();
		// WireMock.reset();
		given().when().get("http://localhost:2020/xml/shopping").then().log().all().assertThat().statusCode(200);

		wireMockServer.stop();
	}

	@Test
	public void testXmlResponsePath() {
		WireMockServer wireMockServer = new WireMockServer(2020); // No-args constructor will start on port 8080, no
																	// HTTPS

		wireMockServer.start();

		Response response = get("http://localhost:2020/xml/shopping");

		// get the first item name
		String firstitemname = response.path("shopping.category.item[0].name");
		System.out.println(firstitemname);

		// get the last item name
		String lastitemname = response.path("shopping.category.item[-1].name"); // try -2
		System.out.println(lastitemname);

		// To get the number of category items:
		int noOfCatItems = response.path("shopping.category.item.size()");
		System.out.println(noOfCatItems);

		// to get a specific category node

		Node nodeCategory = response.path("shopping.category[0]");
		System.out.println(nodeCategory);
		String k = nodeCategory.children().get(0) // this is for <item>
				.children().get(0).toString(); // this is for <name>
		System.out.println("from help >>" + k);

		// first category type >>attribute
		String firstCategory = response.path("shopping.category[0].@type");
		System.out.println(firstCategory);

		// get all categories with attribute = groceries
		int catwithAttributeGroceries = response.path("shopping.category.findAll { it.@type == 'groceries' }.size()");
		System.out.println(catwithAttributeGroceries);

		// Get all items with price greater than or equal to 10 and less than or equal
		// to 20:
		List<Node> itemsBetweenTenAndTwenty = response.path(
				"shopping.category.item.findAll { item -> def price = item.price.toFloat(); price >= 10 && price <= 20 }");
		System.out.println(itemsBetweenTenAndTwenty); // show debug mode

		// Get all items with price greater than or equal to 10 and less than or equal to 20: and first item name	 
		 String firstitemsNamesBetweenTenAndTwenty =response.path("shopping.category.item.findAll { item -> def price = item.price.toFloat(); price >= 10 && price <= 15 }.name[0]");
		 System.out.println(firstitemsNamesBetweenTenAndTwenty); 
		 
		
		// Get the chocolate price:  depth first

		 String priceOfChocolate =response.path("**.find { it.name == 'Chocolate' }.price"); //cannot cast to Integer
    	 System.out.println("choc price is : "+priceOfChocolate);
    	 
    	 //find the shopping type present item price.
    	 String priceOfPaper = response.path("**.find { it.@type == 'present' }.item.price");
    	 System.out.println("paper price : "+priceOfPaper);
    	 
    	 //find the shopping type present as variable.
    	 String shoppingType = "present";
    	 String priceOfPapervar = response.path("**.find { it.@type == '%s' }.item.price", shoppingType );
    	 System.out.println("paper price : "+priceOfPapervar);
    	 
    	 
    
		
		
		wireMockServer.stop();
	}

}
