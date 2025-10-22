# Black-box and White-box Testing Documentation

## Address
### Black-box design techniques (manual analysis)

- Based on requirements, we will test the following cases:

| Partition Type           | Partition          | Test Case Values                                                            |
|--------------------------|--------------------|-----------------------------------------------------------------------------|
| Equivalence Partitioning | Valid Street       | "Vesterbrogade", "Nørregade", "Åboulevard"                                  |
|                          | Invalid Street     | Null, "", " " "123Main", "Main St."                                         |
| Equivalence Partitioning | Valid Number       | "2","500", "998", "500B", "998A"                                            |
|                          | Invalid Number     | "0", "1000", "01", "A12", " ", ""  ,Null                                    |
| Equivalence Partitioning | Valid Floor        | 2, 50, 98, "st"                                                             |
|                          | Invalid Floor      | 0, 100, -1, null (when FloorType != St)                                     |
| Equivalence Partitioning | Valid Door         | "th", "mf", "tv", "2", "49", "A-1", "A-12", A-123, "B1" ,"B12", "B123,"æ-7" |
|                          | Invalid Door       | "0", "51", "door",Null, " ", "", "A--1", "A-1234", "AB-12", "A12B", "A_12"  |
| Boundary Value Analysis  | Number Lower Bound | "1", "1B"                                                                   |
|                          | Number Upper Bound | "999", "999A"                                                               |
| Boundary Value Analysis  | Floor Lower Bound  | 1                                                                           |
|                          | Floor Upper Bound  | 99                                                                          |
| Boundary Value Analysis  | Door Lower Bound   | "1"                                                                         |
|                          | Door Upper Bound   | "50"                                                                        |

### Decision table for the Floor property validation based on your C# logic

| FloorType | Floor (value) | Expected Result | Reason                                         |
|-----------|---------------|-----------------|------------------------------------------------|
| St        | null          | Valid           | Ground floor, no number allowed                |
| St        | 1             | Invalid         | Cannot set both FloorType 'st' and FloorNumber |
| None      | null          | Invalid         | Must set either FloorType or Floor number      |
| None      | 1             | Valid           | Lower boundary                                 |
| None      | 99            | Valid           | Upper boundary                                 |
| None      | 0             | Invalid         | Below lower boundary                           |
| None      | 100           | Invalid         | Above upper boundary                           |
| None      | 50            | Valid           | Typical valid value                            |
| St        | 99            | Invalid         | FloorType 'st' cannot have a number            |

### Decision table for the Door property validation based on your C# logic

| Door (value) | Expected Result | Reason               |
|--------------|-----------------|----------------------|
| th           | Valid           | Typical valid value  |
| mf           | Valid           | Typical valid value  |
| tv           | Valid           | Typical valid value  |
| 1            | Valid           | Lower boundary       |
| 50           | Valid           | Upper boundary       |
| 0            | Invalid         | Below lower boundary |
| 51           | Invalid         | Above upper boundary |
| A-1          | Valid           | Typical valid value  |
| A-1234       | Invalid         | Above upper boundary |

### List of test cases

- **Street**
  - Valid: Vesterbrogade, Nørregade, Åboulevard
  - Invalid: null, "", " ", 123Main, Main St.

- **Number**
  - Valid: 1, 2, 500, 998, 1A, 500B, 998A, 999, 999A
  - Invalid: null, " ", "", 0, 1000, 01, A12

- **Floor**
  - Valid: 1, 2, 50, 98, 99, st
  - Invalid: 0, 100, -1, null, (when FloorType != St)

- **Door**
  - Valid: th, mf, tv, 1, 2, 49, 50, A-1, A-12, A-123, B1, B12, B123, æ-7
  - Invalid: 0, 51, door, null, " ", "", A--1, A-1234, , AB-12, A12B, A_12

### White-box design techniques (automated analysis with tools)

To ensure that Class `Address.cs` is been tested thoroughly, I used the following tools to analyze the code coverage and identify untested paths:

- **Visual Studio Code Coverage**: This tool provides a detailed report of the lines of the code that were executing during the test.
- **ReSharper**: This tool analyzes the code and identifies untested methods and branches. And this suggests additional test cases to cover the path of the test.
- **Live Unit Testing in Visual Studio**: This feature runs tests automatically as code is being written and provides real-time feedback on code coverage.

---
## Phone number
### Black-box design techniques (manual analysis)
Since the phone number generation is randomized, black-box testing focuses on validating the **invariant properties** and **business rules** rather than specific input/output pairs.

| Partition Type           | Partition            | Expected Behavior                                                 |
|--------------------------|----------------------|-------------------------------------------------------------------|
| Equivalence Partitioning | Valid Phone Number   | Always 8 digits, starts with allowed prefix, contains only digits |
| Equivalence Partitioning | Invalid Phone Number | Any deviation from the above rules                                |
| Boundary Value Analysis  | Length Lower Bound   | Must be exactly 8 characters (no less)                            |
| Boundary Value Analysis  | Length Upper Bound   | Must be exactly 8 characters (no more)                            |
| Boundary Value Analysis  | Prefix Validation    | Must start with one of the allowed prefixes                       |

### Decision Table for Phone Number Validation

| Length | Starts with Valid Prefix | Contains Only Digits | Expected Result |
|--------|--------------------------|----------------------|-----------------|
| 8      | Yes                      | Yes                  | Valid           |
| 8      | Yes                      | No                   | Invalid         |
| 8      | No                       | Yes                  | Invalid         |
| 8      | No                       | No                   | Invalid         |
| ≠8     | Yes                      | Yes                  | Invalid         |
| ≠8     | Yes                      | No                   | Invalid         |
| ≠8     | No                       | Yes                  | Invalid         |
| ≠8     | No                       | No                   | Invalid         |
