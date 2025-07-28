# TODO
    * Setup the .http file (assume we have a Cloud Machine available with a static IPv4 & IPv6 address attatched).
    * Create the Datamodels
    * Create the Controllers
    * Docker(?)(For automation)

# Application Sanitization
    * Deployment pipeline
    * SOPS as security solution
    * CI/CD
    * Database sanitization (PostgreSQL or SQLite3)
    * Are secrets visible in the project structure?
        - appsettings.json can expose certain secrets
        - *.http can expose certain secrets
    * Is the application secured when it's exposed to the Internet? (443 SSL, Default to 80?)
    * Can .NET CORE enforce proper SSL-certificates & connect to a CA?

# RestAPI Architecture & Visibility scope
    * What services should be made available?
        * Table of services
            1. Movie service
            2. TV show service  
    * Are there proper encapsulation? (DTOs)
    * Which CRUD operations are available?

# Architecture
    * Model-View-Controller
        - Model (all models are collected within the Model/ folder)
        - View (Not in use)
        - Controller (all controllers are collected within the Controller/ folder)
        - Services (all services are collected within the Services/ folder)
        - Database (all database logic is collected within the Database/ folder)
        - Security (all security modules are collected within the Security/ folder)
        - Tests (all tests modules are collected within the ../Test.sln./Tests/TestModules solution)
    * Frontend
        - Entirely seperate frontend, not a part of the overall architecture of the application.
