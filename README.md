# Industry-4.0

AR application development for Android Devices

Unity version 2020.3.5f1

This application has been developed for use with Samsung Galaxy Tab S7+ along with Festo Factory Machines.

Key Features

I was able to make connection with the factory machine and have this demonstrated on screen with a ‘connection checker’, which would check that the app was connected to all of the factory interfaces, and a ‘connection indicator’ which would change from a red to a green colour when connection was achieved.
If an attempt was made to send an order command when the app was not connected to the machine, a message of ‘not currently connected to the factory’ is displayed for the user. When the machine is connected to the factory machine, it is possible to send build commands for all of the available build options within the machine. This is done by selecting the build options button, which will trigger the build options tab to scroll onto the screen.
Once an order is selected, the options retract and the build options button is disabled while the machine accepts the order, to prevent too many orders being submitted at once. Once an order is complete, the order information for it is displayed in the order data box.

By using the ‘switch to 3D’ button, the user is then able to view a digital twin of the factory (AR mode is set to the default mode on launch of the app). This brings up an approximation of the factory in 3D, and displays a number of data points for the viewer; the number of the factory machine, the last read RFID tag by that machine, and the order number of any order that is currently at that machine.
The carts that are circling are just for demonstration purposes and do not represent the true movements of the carts.
Full order data for all orders is also available through the ‘order info’ bar. When activated with the ‘show order info bar’ button, to side bars swipe in with the available data sets shown on the right, and when selected the data is displayed on the left. 
When switching between AR and 3D mode, these bars are hidden along with the build options bar, to clear any clutter from the screen when switching.



My personal key feature for this app is the emergency stop reader. This is permanently on the screen overlay, both in AR and 3D mode so that the user can always be aware of any activation of the function. This is also represented in the AR mode by an animated ball which changes to red when that stations stop has been activated.
This will then stay active until the emergency stop reset button has been activated on the physical machine.
To enhance this feature further, an alarm sound should be applied to alert the user to the activation.

