# DockCheck-Windows

## Overview
DockCheck-Windows is a sophisticated maritime software solution designed to streamline and enhance the efficiency of maritime operations. This application, developed using .NET and Windows Forms, offers a range of features to facilitate vessel management, docking operations, and crew handling.

## Synchronization and Communication
DockCheck-Windows excels in synchronizing data and communication between a central Master system and multiple Slave devices. This advanced feature ensures seamless, real-time data flow and command execution, vital for maritime operations where timing and accuracy are crucial.

### Asynchronous Communication: 
DockCheck-Windows utilizes asynchronous communication to manage operations without disruption. This approach guarantees continuous operational flow, avoiding downtimes due to timeouts or exceptions.
### Robust Error Handling: 
The system is designed to handle communication errors gracefully. If a Slave device fails to respond, DockCheck-Windows initiates a retry mechanism, ensuring data integrity and continuous operation.
### Cycle Management: 
The software implements a sophisticated cycle management protocol. It intelligently manages the flow of commands and data between Master and Slaves, ensuring that operations are carried out in a sequential and organized manner, adapting dynamically to the number of connected Slaves.
### Real-time Status Updates: 
The user interface is updated in real-time with the current status of operations, providing users with immediate insights into the system's activity and performance.
### Daily Synchronization: 
Each day, the Master fetches approved IDs from the backend and distributes them to the Slaves. This daily synchronization ensures all devices are up-to-date, enhancing security and operational efficiency.

## Features

### User Authentication and Authorization
- **Secure Login System**: Ensures that only authorized users can access the application.
- **Role-Based Access Control**: Different access levels based on user roles to ensure operational integrity.

### Vessel Management
- **Vessel Registration and Tracking**: Allows users to register and track vessels, providing essential information like vessel ID, name, and status.
- **Docking Management**: Facilitates the management of docking operations, including start and end dates, and onboarded personnel count.

### Event Monitoring
- **Real-Time Event Tracking**: Tracks events related to vessels and crew, including timestamps, user IDs, and action details.
- **Camera and RFID Integration**: Monitors vessel and crew movements using camera and RFID technologies.

### Data Management
- **User and Supervisor Management**: Manages user profiles and supervisor roles, including authentication details.
- **Company Profiles**: Handles company-related information, including name, logo, and associated vessels.

### Localization and Internationalization
- **Multi-Language Support**: The application supports multiple languages, enhancing usability for a global user base.

## Technologies Used
- **.NET Framework 4.7.2**: For robust and scalable application development.
- **Windows Forms**: For creating a user-friendly graphical user interface.
- **Google APIs and Newtonsoft.Json**: For handling external data and JSON operations.

## Installation and Setup
Detailed instructions on how to install and configure the application.

## Contributing
Guidelines for contributing to the project, including coding standards and pull request process.

## License
Information about the software license.

## Contact
Contact information for support, feedback, and collaboration.
