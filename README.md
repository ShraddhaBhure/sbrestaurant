# Microservices-based E-Commerce Application

Welcome to the Microservices-based E-Commerce application built using .NET 8. This project is designed to provide a comprehensive example of developing a real microservices architecture. It covers foundational elements, authentication and authorization with .NET Identity, and leverages technologies like Entity Framework Core and Ocelot API Gateway.
![Project Image](https://github.com/ShraddhaBhure/sbrestaurant/blob/master/sbrestaurant.Web/wwwroot/ProjectImages/resto1.PNG)
## Key Highlights and Topics Covered:

# E-Commerce Platform with Azure and Stripe Integration

## Overview

This project is an e-commerce platform built on Azure services and integrated with Stripe for secure payment processing. The platform is designed with microservices architecture to ensure scalability, flexibility, and modularity. It includes modules for product management, shopping cart functionality, order processing, payment transactions, email notifications, user authentication, and more.

## Modules Developed

1. **Product Microservice:**
   - Manages product information.
   - Interacts with Azure SQL Server for data storage.

2. **Shopping Cart Microservice:**
   - Handles shopping cart functionalities using Azure Queues.
   - Supports asynchronous processing of cart-related tasks.

3. **Ordering Microservice:**
   - Manages user orders and updates order status.
   - Communicates with Azure SQL Server for order data.

4. **Payment Microservice:**
   - Manages payment transactions using Stripe integration.
   - Implements server-side validations for secure payments.

5. **Email Microservice:**
   - Sends email notifications using Azure Service Bus Functions.
   - Handles payment confirmation emails.

6. **.NET Identity Microservice:**
   - Handles user authentication and authorization using JWT tokens.

7. **Coupon Microservice:**
   - Manages coupon-related functionalities using Stripe Coupons.

8. **Ocelot Gateway Project:**
   - Implements Ocelot gateway for effective microservices communication.

9. **MVC Web Application:**
   - Provides a user interface consuming APIs from microservices.
   - Integrates with .NET Identity for secure user authentication.

## Getting Started

1. **Prerequisites:**
   - Azure account with necessary resources provisioned.
   - Stripe account for payment processing.
   - Visual Studio or any compatible code editor.

2. **Configuration:**
   - Update configuration files with Azure and Stripe credentials.
   - Configure JWT settings in the .NET Identity Microservice.

3. **Run Locally:**
   - Clone the repository.
   - Build and run each microservice and the MVC Web Application.

4. **Deployment:**
   - Deploy microservices on Azure App Service.
   - Configure Azure SQL Server, Queues, Topics, and Service Bus.
   - Update application settings for production deployment.

## Usage

1. Access the MVC Web Application.
2. Browse products, add them to the cart, and place orders.
3. Make payments securely using the integrated Stripe functionality.
4. Receive email notifications for payment confirmation.

## Contributing

Contributions are welcome! Please follow our [Contribution Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).


## Getting Started
Follow these steps to get the project up and running on your local machine:

1. Clone the repository: `git clone https://github.com/ShraddhaBhure/sbrestaurant.git`

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Acknowledgments
Special thanks to the contributors and the open-source community for making this project possible. If you have any questions or feedback, feel free to open an issue or reach out to us. Happy coding!
