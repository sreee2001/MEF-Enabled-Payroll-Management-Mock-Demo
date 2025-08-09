# MEF-Enabled Payroll Management Mock Demo

## Introduction

This project demonstrates the use of the Managed Extensibility Framework (MEF) in a payroll management system. It showcases how MEF can be leveraged to create a modular, extensible architecture for processing payroll operations, making it easy to add new features and components without modifying the core system.

## Table of Contents

1. [Introduction](#introduction)
2. [Solution Structure](#solution-structure)
3. [Building and Deploying](#building-and-deploying)
4. [Extending the Project with MEF](#extending-the-project-with-mef)

## Solution Structure

The solution is organized into several key projects, each serving a specific purpose:

- **Interfaces**
  
  Contains core interfaces.
  * `Entities`
    * `ICompany`
    * `IState`
  * `BusinessObjects`
    * `IPayrollRegistration`    

- **Models**
  
  Houses implementations of Interfaces.
  * `Entities`
    * `Country`
    * `State`
  * `BusinessObjects`
    * `PayrollRegistration`

- **PayrollProcessor**
  
  Provides implementation of payroll system. Its in here that we import `IPayrollRegistration` objects and process them based on commands
  * `IPayrollService`
  * `PayrollService`

- **RegistrationAtLaunch**  

  Its in here that we registered companies for payroll service. For the sake for this demo, This is what we will assume that was shipped when initially deployed.
  We register an entry for each Company and the TaxState we wanted to process the payroll
  So if we want a company names "First Company" to have payroll processed in states "First State" and "Second State"
  we register them as follows

    ````C#
    [Export(typeof(IPayrollRegistration))]
    public class FirstCompanyFirstState : PayrollRegistration
    {
        public FirstCompanyFirstState() : base("First Company", "First State") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            // This will be where Company and State specific Payroll processing be implemented
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }
    [Export(typeof(IPayrollRegistration))]
    public class FirstCompanySecondState : PayrollRegistration
    {
        public FirstCompanySecondState() : base("First Company", "Second State") { }

        public override void RunPayrollForCompany(ICompany company, IState state)
        {
            // This will be where Company and State specific Payroll processing be implemented
            Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
        }
    }
    ````
  

## Building and Deploying

1. **Prerequisites**  
   - [.NET SDK](https://dotnet.microsoft.com/download) (version 4.7.2 or higher)
   - Visual Studio or another compatible IDE

2. **Build Steps**  
   - Clone the repository:  
     `git clone https://github.com/sreee2001/MEF-Enabled-Payroll-Management-Mock-Demo.git`
   - Open the solution in Visual Studio.
   - Restore NuGet packages and build the solution (`Build > Build Solution`).

3. **Deploying Binaries**  
   - Run the `PayrollManagement.UI` project to launch the demo application.
   - Compiled binaries will be located in the `/bin/Debug` or `/bin/Release` folder in the Solution Directory. Note: I have changed the build output path.

## Extending the Project with MEF

To expand the system using MEF:

1. **Create a New Plugin Project**
   - Add a new Class Library project to the solution.
   - Reference `Interfaces` and `Models`.

2. **Implement Required Interfaces and Export Components with MEF**
   - Create classes that implement `PayrollRegistration` and Export them as type `IPayrollRegistration`.
   - Use the `[Export]` attribute to mark your classes as MEF components.

   - For Example to add additional payroll registration, say for Adidas in California
   - use the following code:

   ````C#
   [Export(typeof(IPayrollRegistration))]
   public class AdidasCalifornia : PayrollRegistration
   {
       public AdidasCalifornia() : base("Adidas", "California") { }
       public override void RunPayrollForCompany(ICompany company, IState state)
       {
           // This will be where Company and State specific Payroll processing be implemented
           Console.WriteLine($"Running custom payroll for {company.Name} in state {state.Name}.");
       }
   }
   ````

3. **Deploy Plugins**
   - Place the compiled plugin DLL in the designated plugins folder recognized by the UI which is `$(SolutionDir)/bin/Debug` or `$(SolutionDir)/bin/Release`.
   - Restart the application; MEF will discover and load the new plugin automatically.
  
4. **Sample Implementation**
   - PhaseOneExtension is a library that is added after the entire code is deployed. If manually deploying this project, copy the dll to where the application is installed and scanning. Restart the application
     - It only contains example of additional workloads
       - Company : Adidas , States : California, Texas and Utah
       - Company : Walmart, States : Texas, Florida and Ohio
 - When the appliaction is run, it will detect this additional dll and load it and with it the above workflows will be available
 - To test further, go to the deployment location, manually delete this dll and restart the application. It will revert to the original options
