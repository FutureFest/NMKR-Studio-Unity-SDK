# NMKR Studio Unity SDK Demo Project
An example of how the SDK can be used. Only for learning purposees and not for production.

## **Getting Started**

1) If you're getting missing dependencies after importing the demo project. Import the following packages as dependencies:
*'', Cloud Save, 3.0.0
*'com.unity.services.authentication', Authentication, 3.2.0

Restart the Unity Editor if needed.


2) Go to demo scene "NmkrDemo", this will be the starting point of the demo.

3) Go to the gameobject in the heirarchy named "API Initialization" and fill in your Customer Id and API Key found on your NMKR Studio account. Note Preprod and Production NMKR Studio accounts have different API Keys and Customer Ids.

4) There are example store front items under 'Demo/Data'. These items need the ProjectUID from the project you want to mint from found on NMKR Studio site. Change these items or create your own storefront items according to your nfts in your NMKR Studio project. Add these items to the UIManager's Storefront Items found on "DemoUI" gameobject in the "NmkrDemo" scene.

5) Press play on the scene to test functionality locally.

6) Your username and password will be saved and used again for testing purposes.