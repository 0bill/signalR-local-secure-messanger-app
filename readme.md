# Desktop Messenger Application [prototype] [academic]
server and client application build using .NET CORE and SignalR. A chat application that allows for secure communication within the company in real-time. The program uses SignalR to communicate between the server and each client.

### Scope
The project is to create an application for DOGE FINANCIAL, which will be used for communication between company users. The program should be characterized by a high level of security, since the data transmitted are sensitive and require special treatment and protection from third parties. In addition, the program should send data between users as quickly as possible - in real time. The only place where data are stored is the database, which is hosted on the company's server. Only verified employees can use the program, they get access with the appropriate login and password.

![App overview 4](./Images/4.PNG)

## Key features
### Security 
- Password encryption 
- Message encryption 
- Tokens
- Session
- Hold data in client memory 

### Patterns
- Dependency injection 
- MVC/MVP 
- Repository pattern + Entity Framework 
- Singleton
- Real-Time 
- Application Layers 

## Specific requirements
### Functional requirements
- Login to the application
- Sending messages 
- Receiving messages 
- Starting a conversation 
- Viewing the user list 
- Message encryption 
- Minimal latency 
- Microsoft Windows 7 compatibility 
- Copy of messages 
- Message sound 
- Remove old messages 
 ### Non-functional requirements 
- Offloading the database 
- Connection security 
- Professional application template 
- User management 
- Work in a remote network 
- Preventing multi-logging 
- Session

![App overview 3](./Images/3.jpg)
![App overview 1](./Images/1.jpg)
![App overview 2](./Images/2.jpg)


# Diagrams 
![image](https://user-images.githubusercontent.com/28375942/136117612-ac7cd647-275a-460b-bf43-f7017454e5c1.png)
![image](https://user-images.githubusercontent.com/28375942/136117773-473243ee-6184-4a77-8a3d-3b13b49eef40.png)
![image](https://user-images.githubusercontent.com/28375942/136117792-46c7a58a-be18-43a8-b586-301adc977d04.png)
![image](https://user-images.githubusercontent.com/28375942/136117809-b09c8588-e1a3-419a-b53e-c27f4464268d.png)
![image](https://user-images.githubusercontent.com/28375942/136117818-fe1504a1-c19c-456f-af4e-44bdba74b141.png)
![image](https://user-images.githubusercontent.com/28375942/136117831-bb2e2df0-cd5e-4638-bd2d-5fc80a7d6199.png)

# Timeline 
![image](https://user-images.githubusercontent.com/28375942/136117859-2f4d8130-0a50-40f8-8532-1fe3e64256b1.png)

# Testing
On the one hand, the test object was the application code, on the other hand the 
application itself on the user's side. To this end, techniques called white and black box tests 
were used. Testing the white box allowed to test the program based on the internal structure 
of the application. To achieve this, applications were tested using unit tests where they could 
be used. 
![image](https://user-images.githubusercontent.com/28375942/136117695-6e65a792-28b2-4714-85d3-ed4d7664e047.png)

Because the application has a complex structure, it uses several frameworks and the logic has 
been divided between the server and the client. Therefore, the program was also tested as a 
product. For this purpose, we will use a technique called Black Box. Testing consisted of testing 
individual functions of the application by following specific steps and using various types of 
input data (normal, exceptional and extreme); making sure that the data received during the 
tests are as expected.




