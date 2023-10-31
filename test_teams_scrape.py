import csv
import datetime
import os
import pytest
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.wait import WebDriverWait
from datetime import datetime
# from selenium_stealth import stealth

from selenium.webdriver.common.action_chains import ActionChains
from selenium.webdriver.common.keys import Keys
import time  

input_dataFile ='../InputData/teams.csv'
log_file_path = '../Logs/TeamsScrapeLog.csv'
driver = None
url = 'https://teams.microsoft.com/'


@pytest.fixture(scope="session", autouse=True)
def setup_before_tests():
    # Perform setup actions before running any tests
    print("Setup actions before running tests")
    delete_file_if_exists(log_file_path)
    write_to_file(log_file_path,"Name,Department,TimeZone,Other"+'\n')
    global driver 
    driver = webdriver.Chrome()
    driver.implicitly_wait(10)
    driver.maximize_window()
    driver.get(url)
    # Manulaly loginto to the teams account till the desired page.
    time.sleep(25)
    yield

def read_test_data_from_csv():
    test_data = []
    
    with open(input_dataFile, newline='') as csvfile:
        data = csv.reader(csvfile, delimiter=',')
        next(data)  # skip header row
        for row in data:
            test_data.append(row)
    return test_data



@pytest.mark.parametrize("FLName", read_test_data_from_csv())
def test_Scrape_TeamsInfo(FLName):
    FLName = ' '.join(FLName)
    print("Scrapring data for : "+str(FLName))
    log_info= FLName
    
    try:
        srchElement = driver.find_element(By.ID,"control-input")
        actions = ActionChains(driver)
        actions.click(srchElement).send_keys(FLName).send_keys(Keys.ENTER).perform()
        time.sleep(1)

        # Switch to iframe
        iframe = driver.find_element(By.XPATH,"//iframe")
        driver.switch_to.frame(iframe)

        actions = ActionChains(driver)
        profilePicElement = driver.find_element(By.XPATH,"//h4[text()='People']/following::div[1]//img")
        actions.move_to_element(profilePicElement).perform()
        time.sleep(2)

        departmentName = driver.find_element(By.XPATH,"//div[@data-log-name='Department']").text
        print(departmentName)

        timeZone = driver.find_element(By.XPATH,"//*[name()='svg' and @aria-label='Clock']/following-sibling::p").text
        print(timeZone)
        
        log_info = log_info+","+departmentName+","+timeZone+","+get_time_stamp()
    except Exception as e:
        print(e)
        print("Error in scappring data for : "+FLName)
        log_info = log_info+","+"ERROR !!!"
    finally:
        print ("Scrape completed for : "+FLName)
        append_line_to_file(log_file_path, log_info)
        





def append_line_to_file(file_path, line_content):
    with open(file_path, 'a') as file:
        file.write(line_content + '\n')


def delete_file_if_exists(file_path):
    if os.path.exists(file_path):
        try:
            os.remove(file_path)
            print(f"File '{file_path}' deleted successfully.")
        except Exception as e:
            print(f"Error deleting file: {e}")
    else:
        print(f"File '{file_path}' does not exist.")
        
        
def write_to_file(file_path, content):
    with open(file_path, "w") as file:
        file.write(content)                
        
def get_time_stamp():
    timestamp = datetime.now()
    timestamp_str = timestamp.strftime("%Y-%m-%d %H:%M:%S")
    return timestamp_str


@pytest.fixture(scope="session", autouse=True)
def tear_down(request):
    yield
    print("Quitting the Browser")
    driver.quit()
    
