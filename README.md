# DockCheck-Windows

![Screenshot 2024-01-13 at 17 58 22](https://github.com/lucland/DockCheck-Windows/assets/17681714/24fd4e66-05e7-4f4e-b859-017608c700db)

## Overview
  DockCheck-Windows is a cutting-edge maritime software solution crafted to streamline and enhance the efficiency of maritime operations. Built with .NET and Windows Forms, it boasts an array of features to facilitate vessel management, docking operations, and crew handling, standing out for its capability to autonomously track every worker on a vessel during docking.

### Synchronization and Communication
  DockCheck-Windows excels in data synchronization and communication between a central Master system and multiple Slave devices, ensuring real-time data flow and command execution, vital for maritime operations where timing and accuracy are paramount.

#### Asynchronous Communication:
  DockCheck-Windows employs asynchronous communication to manage operations without interruption, ensuring a continuous operational flow and avoiding downtime due to timeouts or exceptions.

#### Robust Error Handling:
  The system is elegantly designed to handle communication errors. If a Slave device fails to respond, DockCheck-Windows initiates a retry mechanism, safeguarding data integrity and operation continuity.

#### Cycle Management:
  The software implements an intricate cycle management protocol, smartly managing the flow of commands and data between Master and Slaves, ensuring operations are conducted sequentially and in an organized manner, dynamically adapting to the number of connected devices.

#### Real-time Status Updates:
  The user interface provides real-time updates on the current status of operations, offering users immediate insights into the system's activity and performance.

#### Daily Synchronization:
  Each day, the Master retrieves approved IDs from the backend and distributes them to the Slaves. This daily sync ensures all devices are up-to-date, enhancing security and operational efficiency.

## Features

### User Authentication and Authorization
  #### Secure Login System: 
  Ensures that only authorized users can access the application.
  #### Role-Based Access Control: 
  Different access levels based on user roles to ensure operational integrity.

### Vessel Management
  #### Vessel Registration and Tracking: 
  Enables users and commanders to register and track crew onboard and the vessel, providing essential information such as ID, name, company, and each employee's responsibility while      providing general data about the vessel.
  #### Docking Management: 
  Facilitates the management of docking operations, including start and end dates, and personnel count onboard, and records hours worked by each person at specific dock locations.

### Event Monitoring
  #### Real-Time Event Tracking: 
  Monitors events related to vessels and crew, including timestamps, user IDs, and action details.
  #### Camera and BLE Integration: 
  Tracks vessel and crew movements using camera and BLE technologies for precise triangulation.

### Data Management
  #### User and Supervisor Management: 
  Manages user profiles and supervisor roles, including authentication details and access permissions within the vessel.
  #### Company Profiles: 
  Handles information related to third-party companies, including employees, contracted work, start and end of activity, and associated vessels.

### Localization and Internationalization
  #### Multi-Language Support: 
  The application supports multiple languages, improving usability for a global user base.
  #### Foreign Document Registration Support:
  The application deals with the registration and checking of international work permissions and identification documents.

### Security Alert and Incident Monitoring Features
  DockCheck-Windows introduces advanced security alert functionalities and real-time incident monitoring, ensuring the safety of maritime operations:
  - **Precise Personnel Counting**: Counts and monitors the exact number of people in each specific location of the vessel and docking area, knowing who is present and their three-         dimensional geographic position, including the height at which they are located on the ship.
  - **Incident Response**: In case of incidents, it identifies who is yet to evacuate from the affected area, and instantaneously alerts companies, authorities, and crew, providing         precise data about the incident to assist in the most efficient manner possible.

### Project Technologies
  .NET, NodeJS, PostgreSQL, Flutter, Python, and AWS

### Overcoming Challenges
  #### High Volume of Data: 
  The system is engineered to handle substantial volumes of data, ensuring efficiency and robustness in information analysis and processing.
  #### Autonomous Tracking: 
  Implementation of a 100% autonomous tracking system using sensors in a communication mesh, providing unprecedented insights into the naval industry.
  #### Worker Safety: 
  Prioritizing worker safety, promoting a safer and more efficient work environment.
  #### Industry 4.0: 
  sAdvancing the naval industry's transition to the era of Industry 4.0, leveraging the analysis and processing of large volumes of data.
