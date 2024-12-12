# Citizen Statistics

A web application to manage and analyze citizen statistics, built using ASP.NET Core MVC. The application provides functionality for managing citizen data, including their age, income, and profession, and calculating various statistical metrics like average age, median age, highest income, and top-paying professions.

## Features

- **Citizen Management**:
  - Add new citizens with details like age, income, and profession.
  - Edit existing citizen records.
  - Delete citizens from the database.
  
- **Statistics**:
  - Calculate average age.
  - Determine the median age.
  - Identify the highest and lowest incomes.
  - List top-paying professions.

- **Data Persistence**:
  - Uses SQLite for storing citizen data.

## Technology Stack

- **Frontend**:
  - Razor Views with ASP.NET Core MVC.

- **Backend**:
  - ASP.NET Core MVC.
  - Entity Framework Core.

- **Database**:
  - SQLite.

- **Testing**:
  - Unit tests using xUnit and NSubstitute.

## Testing

Testing is a crucial part of the application to ensure robustness and reliability. The project includes comprehensive unit tests for both controllers and services.

### CitizenController Tests

1. **Create Citizen**:
   - Verifies that a valid citizen redirects to the index page.
   - Tests invalid submissions to ensure proper error handling and model validation.

2. **Edit Citizen**:
   - Ensures valid edits redirect to the index.
   - Checks invalid models to confirm errors are displayed without altering the data.

3. **Delete Citizen**:
   - Validates the correct removal of citizens and redirection to the index.
   - Confirms that non-existing citizen deletions return a "Not Found" response.

### StatisticsService Tests

1. **Average Age**:
   - Validates accurate calculation of average age from the data set.

2. **Median Age**:
   - Tests the computation for both odd and even numbers of citizens.

3. **Income Extremes**:
   - Confirms correct identification of highest and lowest incomes.

4. **Top-Paying Professions**:
   - Ensures the correct professions are identified based on income.

5. **Edge Cases**:
   - Tests behavior when there are no citizens (returns default values).

### Running Tests

To run the tests, execute:

```bash
dotnet test
```

Ensure all tests pass to maintain the application's reliability. Expand the test suite as new features are added to cover additional scenarios.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- .NET 6.0 SDK or higher
- SQLite
- A compatible IDE like Visual Studio or Visual Studio Code

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/Victor19941221/citizen-statistics.git
   cd citizen-statistics
   ```

2. Restore NuGet packages:

   ```bash
   dotnet restore
   ```

3. Run the application:

   ```bash
   dotnet run
   ```


### Database Setup

The application uses SQLite as its database. The database file `citizensData.db` will be automatically created in the project directory on the first run.

## Usage

### Adding a Citizen

1. Navigate to the "Citizen" page.
2. Click "Add Citizen."
3. Fill in the citizen's details and click "Submit."

### Viewing Statistics

1. Navigate to the home page.
2. View metrics like average age, median age, highest income, lowest income, and top-paying professions.

### Editing or Deleting a Citizen

1. Navigate to the "Citizen" page.
2. Click "Edit" or "Delete" next to the desired citizen.

## Pictures

Here is a screenshot showing the results of the tests

[Application Screenshot](https://imgur.com/a/cKwfzvd)



