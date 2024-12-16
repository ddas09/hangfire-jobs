# Hangfire Background Job Scheduler

This project is a sample application demonstrating how to schedule and execute background jobs in .NET using the [Hangfire](https://www.hangfire.io/) library.

## Project Structure

The project is organized into the following directories:

- **Hangfire.Jobs.Api**: Contains the API layer for interacting with the Hangfire background job scheduler.
- **Hangfire.Jobs.Core**: Contains the core logic and business rules related to the background jobs.
- **Hangfire.Jobs.DAL**: Handles data access and persistence for the application.
- **Hangfire.Jobs.Scheduler**: Implements the scheduler logic for queuing the background jobs.
- **Hangfire.Jobs.Server**: This console application is responsible for picking up job from the queue and executing them. Running multiple instance will scale the server.
- **Hangfire.Jobs.Services**: Includes the business layer logic used throughout the application.

## Getting Started

To run the application locally, follow these steps:

1. Clone this repository to your local machine.
2. Navigate to the root directory of the project.
3. **Update Connection Strings**:
   - Open the `appsettings.json` file in the following projects: `Hangfire.Jobs.Api`, `Hangfire.Jobs.Scheduler`, and `Hangfire.Jobs.Server`.
   - Replace the default connection string with your local database connection string. This ensures that the application can connect to the database for storing job-related data.

4. **Build and Run Scheduler and Server**:
   - Open two separate command prompt or terminal windows.
   - Navigate to the directories for the Scheduler and Server projects (`Hangfire.Jobs.Scheduler` and `Hangfire.Jobs.Server`).
   - Use the .NET CLI to run the applications:
     ```
     dotnet run
     ```
   - The Scheduler and Server applications should start, and you should see console output indicating that they are running and listening for job requests.

5. **Build and Run API**:
   - Open another command prompt or terminal window.
   - Navigate to the directory for the API project (`Hangfire.Jobs.Api`).
   - Build and run the API using the .NET CLI:
     ```
     dotnet run
     ```
   - The API should start, and you should see console output indicating that it's listening for HTTP requests.

6. **Access the API Endpoints**:
   - Open your web browser or API testing tool (e.g., Postman).
   - Use the provided API endpoints to schedule and manage background jobs. The API documentation should be available at `http://localhost:<PORT>/swagger` (replace `<PORT>` with the actual port number configured for the API).

7. **Monitor Job Execution**:
   - You can access the hangfire dashboard at `http://localhost:<PORT>/hangfire` (replace `<PORT>` with the actual port number configured for the API). Also monitor the console output of the Scheduler and Server applications to observe job execution and processing.

8. **Cleanup**:
   - Once you're done testing, stop the Scheduler, Server, and API applications by pressing `Ctrl + C` in their respective terminal windows.
   - Optionally, clean up any job-related data from the database as needed.

Following these steps should allow you to set up and run the Hangfire background job scheduler application locally for testing and development purposes.

## Scheduler and Server

In this application, there are two key components responsible for the execution of background jobs:

### Scheduler (Hangfire.Jobs.Scheduler)

The Scheduler module is responsible for queuing and scheduling background jobs. It handles the logic for when jobs should be executed and manages their placement in the job queue. This component ensures that jobs are scheduled efficiently and according to the defined criteria.

### Server (Hangfire.Jobs.Server)

The Server module is responsible for executing the background jobs that have been scheduled by the Scheduler. It continuously monitors the job queue for any pending tasks and executes them based on their priority and availability. This component ensures that the scheduled jobs are processed in a timely and orderly manner.

By separating the scheduling and execution responsibilities, the application can efficiently manage and scale its background job processing, ensuring reliable performance and responsiveness.

## Registering Recurring Jobs

In the `Hangfire.Jobs.Scheduler` project, recurring jobs can be registered in the `JobScheduler.cs` file. Recurring jobs are those that need to be executed periodically according to a defined schedule. Here's how you can register recurring jobs:

1. Open the `JobScheduler.cs` file located in the `Hangfire.Jobs.Scheduler` project.

2. Inside the `ScheduleJobs()` method, instantiate and call the `Schedule()` method of your custom job class. This method should be responsible for registering the recurring job. Look at some existing job classes for reference.

   Example:
   ```csharp
   public void ScheduleJobs()
   {
       // Instantiate your custom job class
       var customJob = new CustomJob(/* pass dependencies if any */);
       
       // Call the Schedule() method to register the recurring job
       customJob.Schedule();
   }

## Contributing

1. Fork the repository.

2. Create a new branch:
   ```bash
   git checkout -b feature/your-feature
   ```
3. Make your changes.
4. Commit your changes 
   ```bash
   git commit -a 'Add new feature'
   ```
5. Push to the branch 
   ```bash
   git push origin feature/your-feature
   ```
6. Create a new Pull Request.

## License
This project is open-source and licensed under the [MIT License](https://opensource.org/license/mit).
