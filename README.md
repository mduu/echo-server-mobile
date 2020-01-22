# echo-server-mobile
Xamarin Forms Mobile App that opens a TCP-Listener and does an echo server.

The TCP-Server itself can be found [here](https://github.com/mduu/echo-server-mobile/blob/master/Echo.Server/Services/TcpServer.cs).

## Run the app

1. Download the source and compile it eg. using Visual Studio Mac.
1. Set the iOS app as the start project.
1. Start the app so the iOS simulator open and your app gets started in the simulator.
1. Open the telnet connect to 127.0.0.1 port 42424.
1. Enter "hi" (ENETER) on the keyboard. You should get a hi.
1. Enter random data and you see on the console.
