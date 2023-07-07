package com.restassured.tests;

import static io.restassured.RestAssured.get;
import static org.hamcrest.Matchers.*;
import static io.restassured.RestAssured.given;

import java.util.List;
import java.util.Map;

import org.testng.annotations.Test;

import com.github.tomakehurst.wiremock.WireMockServer;

import io.restassured.response.Response;

public class E18_JsonResonseBodyTraverse {

	// @Test
	public void testJsonResponse() {
		WireMockServer wireMockServer = new WireMockServer(2020); // No-args constructor will start on port 8080, no
																	// HTTPS

		wireMockServer.start();
		// WireMock.reset();
		given().when().get("http://localhost:2020/json/books").then().log().all().assertThat().statusCode(200)
				.body("store.book[0].category", equalTo("reference"));

		wireMockServer.stop();
	}

	@Test
	public void testJsonResponseExamples() {
		WireMockServer wireMockServer = new WireMockServer(2020); // No-args constructor will start on port 8080, no
																	// HTTPS

		wireMockServer.start();

		Response response = get("http://localhost:2020/json/books");

		// get the first book
		String firstBook = response.path("store.book[0].title");
		System.out.println(firstBook);

		// gets the last book and -2 is for last but one.. and so on..
		String lastBook = response.path("store.book[-1].title"); // try -2
		System.out.println(lastBook);

		// to get all the authors in book array
		List<String> authors = response.path("store.book.author");
		System.out.println(authors);
		
		//get number of authors
    	int authorsSize= response.path("store.book.author.size()");
     	System.out.println(authorsSize);

		// Get all books with price between 5 and 15:
		List<Map> books = response.path("store.book.findAll { book -> book.price >= 5 && book.price <= 15 }");
		System.out.println(books);

		// just get the titles of book priced between 5 and 15
		List<String> booksTitles = response
				.path("store.book.findAll { book -> book.price >= 5 && book.price <= 15 }.title");
		System.out.println(booksTitles);

		// find book of a particular author
		List<Map> authorNameBook = response.path("store.book.findAll { book -> book.author == 'Nigel Rees' }");
		System.out.println(authorNameBook);
		
		
		
		//pass the name as parameter
		String author = "Nigel Rees";
     	List<Map> authorNameBookp = response.path("store.book.findAll { book -> book.author == '%s' }",author );
     	System.out.println(authorNameBookp);
     	
     	
     	 // using find to filter results
     	Map<String,?> authorNameBookfind = response.path("store.book.find { it.author == 'Nigel Rees' }");
     	System.out.println(authorNameBookfind);
     	
     	//using find and it  to find the price of book authored by Nigel.
     	float authorNameBookfindprice = response.path("store.book.find { it.author == 'Nigel Rees' }.price");
     	System.out.println(authorNameBookfindprice);
     	
     	//pass parameter with find filter
     	float authorNameBookfindpriceStringsubstitite = response.path("store.book.find { it.author == '%s' }.price", "Nigel Rees");
     	System.out.println(authorNameBookfindpriceStringsubstitite);
     	
     	//using findall filter and it keyword
     	List<Map> booksIt = response.path("store.book.findAll { it.price >= 10}");
     	System.out.println(booksIt);
     	
     	List<Map> booksIt2 = response.path("store.book.findAll { it.price >= 10 && it.price <= 20 }");
     	System.out.println(booksIt2);
     	
     	List<String> booksIt2title = response.path("store.book.findAll { it.price >= 10 && it.price <= 20 }.title");
     	System.out.println(booksIt2title);
     	
//use of functions
     	
     	//highest price
     	String booksIt2titlehighprice = response.path("store.book.max { it.price }.title");
     	System.out.println(booksIt2titlehighprice);
     	
     	//lowest price
     	String booksIt2titlelowestprice = response.path("store.book.min { it.price }.title");
     	System.out.println(booksIt2titlelowestprice);
     	
    	//sum of the price
     	double sumOfPrice = response.path("store.book.collect { it.price }.sum()");
     	System.out.println(sumOfPrice);
     	
     	
     	
     	
		wireMockServer.stop();
	}

}
