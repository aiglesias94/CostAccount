# Project Overview

## Architecture

This project is implemented using a three-layer architecture:

- **CostAccount_BAL**: Business Access Layer, containing the services.
- **CostAccount_DAL**: Data Access Layer, containing the models and repositories.
- **CostAccount**: Main project and the presenter layer.

## Technology Stack

- I created the project in .Net 8 which is the latest long-term support version and using simple razor pages for the presenter layer, since the assessment indicated that this would be used for evaluating C#.
- Implemented a dummy database using lists as indicated.

## Improvements for Real-Life Scenarios

Several enhancements could be made in a real-life scenario:

- **Presentation Layer**: Can be changed to a Single Page Application (SPA).
- **Queue Service**: Utilize a queue service for processing sales requests.
- **User Session and Authentication**: Add user session management and authentication.
- **Real Database**: Implement a real database for persistent data storage.
- **Auto Mapper**: Use an auto mapper for converting the model to DTOs.
- **Caching**: Add caching for loading stocks and sales history.
- **Error Handling**: Incorporate better error handling using custom errors and metrics.
