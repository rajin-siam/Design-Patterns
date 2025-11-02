# Observer Pattern - Weather Monitoring System

A C# implementation of the Observer Design Pattern demonstrating a weather monitoring system where multiple display elements observe and react to weather data changes.

## Overview

This project demonstrates the Observer pattern, a behavioral design pattern that establishes a one-to-many dependency between objects. When the subject (WeatherData) changes state, all registered observers (display elements) are automatically notified and updated.

## Pattern Structure

### Interfaces

- **Subject**: Defines methods for registering, removing, and notifying observers
- **Observer**: Defines the update method that observers must implement
- **DisplayElement**: Defines the display method for presenting information

### Components

#### Subject
- **WeatherData**: Maintains weather measurements (temperature, humidity, pressure) and manages observer subscriptions

#### Observers
- **CurrentConditionsDisplay**: Displays current weather conditions
- **StatisticsDisplay**: Shows weather statistics
- **ForecastDisplay**: Presents weather forecast information

## How It Works

1. Observer objects register themselves with the WeatherData subject
2. When weather measurements change via `SetMeasurements()`, the subject notifies all registered observers
3. Each observer receives updated data through the `update()` method
4. Observers automatically display the new information

## Class Diagram

```mermaid
classDiagram
    class Subject {
        <<interface>>
        +RegisterObserver(Observer)
        +RemoveObserver(Observer)
        +NotifyObservers()
    }
    
    class Observer {
        <<interface>>
        +update(float, float, float)
    }
    
    class DisplayElement {
        <<interface>>
        +display()
    }
    
    class WeatherData {
        -ArrayList observers
        -float temperature
        -float humidity
        -float pressure
        +RegisterObserver(Observer)
        +RemoveObserver(Observer)
        +NotifyObservers()
        +SetMeasurements(float, float, float)
        -MeasurementsChanged()
    }
    
    class CurrentConditionsDisplay {
        -float temperature
        -float humidity
        -Subject weatherData
        +update(float, float, float)
        +display()
    }
    
    class StatisticsDisplay {
        -float temperature
        -float humidity
        -Subject weatherData
        +update(float, float, float)
        +display()
    }
    
    class ForecastDisplay {
        -float temperature
        -float humidity
        -Subject weatherData
        +update(float, float, float)
        +display()
    }
    
    Subject <|.. WeatherData : implements
    Observer <|.. CurrentConditionsDisplay : implements
    Observer <|.. StatisticsDisplay : implements
    Observer <|.. ForecastDisplay : implements
    DisplayElement <|.. CurrentConditionsDisplay : implements
    DisplayElement <|.. StatisticsDisplay : implements
    DisplayElement <|.. ForecastDisplay : implements
    WeatherData o--> Observer : notifies
    CurrentConditionsDisplay --> Subject : observes
    StatisticsDisplay --> Subject : observes
    ForecastDisplay --> Subject : observes
```

## Program Flow

```mermaid
sequenceDiagram
    participant P as Program
    participant WD as WeatherData
    participant CD as CurrentConditionsDisplay
    participant SD as StatisticsDisplay
    participant FD as ForecastDisplay
    
    P->>WD: new WeatherData()
    P->>CD: new CurrentConditionsDisplay(weatherData)
    CD->>WD: RegisterObserver(this)
    P->>SD: new StatisticsDisplay(weatherData)
    SD->>WD: RegisterObserver(this)
    P->>FD: new ForecastDisplay(weatherData)
    FD->>WD: RegisterObserver(this)
    
    Note over P,FD: First Measurement Update
    P->>WD: SetMeasurements(80, 65, 30.4f)
    WD->>WD: MeasurementsChanged()
    WD->>WD: NotifyObservers()
    WD->>CD: update(80, 65, 30.4f)
    CD->>CD: display()
    WD->>SD: update(80, 65, 30.4f)
    SD->>SD: display()
    WD->>FD: update(80, 65, 30.4f)
    FD->>FD: display()
    
    Note over P,FD: Second Measurement Update
    P->>WD: SetMeasurements(82, 70, 29.2f)
    WD->>WD: MeasurementsChanged()
    WD->>WD: NotifyObservers()
    WD->>CD: update(82, 70, 29.2f)
    CD->>CD: display()
    WD->>SD: update(82, 70, 29.2f)
    SD->>SD: display()
    WD->>FD: update(82, 70, 29.2f)
    FD->>FD: display()
    
    Note over P,FD: Third Measurement Update
    P->>WD: SetMeasurements(78, 90, 29.2f)
    WD->>WD: MeasurementsChanged()
    WD->>WD: NotifyObservers()
    WD->>CD: update(78, 90, 29.2f)
    CD->>CD: display()
    WD->>SD: update(78, 90, 29.2f)
    SD->>SD: display()
    WD->>FD: update(78, 90, 29.2f)
    FD->>FD: display()
```

## Project Structure

```
ObserverPattern/
??? Interfaces/
?   ??? Subject.cs
?   ??? Observer.cs
?   ??? DisplayElement.cs
??? Subjects/
?   ??? WeatherData.cs
??? Observers/
?   ??? CurrentConditionsDisplay.cs
?   ??? StatisticsDisplay.cs
?   ??? ForecastDisplay.cs
??? Program.cs
```

## Usage Example

```csharp
// Create the subject
WeatherData weatherData = new WeatherData();

// Create and register observers
CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

// Update measurements - all observers are automatically notified
weatherData.SetMeasurements(80, 65, 30.4f);
weatherData.SetMeasurements(82, 70, 29.2f);
weatherData.SetMeasurements(78, 90, 29.2f);
```

## Output

```
Current conditions: 80F degrees and 65% humidity
Statistics: 80F degrees and 65% humidity
Forecast: 80F degrees and 65% humidity
Current conditions: 82F degrees and 70% humidity
Statistics: 82F degrees and 70% humidity
Forecast: 82F degrees and 70% humidity
Current conditions: 78F degrees and 90% humidity
Statistics: 78F degrees and 90% humidity
Forecast: 78F degrees and 90% humidity
```

## Requirements

- .NET 8.0
- C# 12.0 or later

## Key Benefits

- **Loose Coupling**: Subject and observers are loosely coupled and can vary independently
- **Dynamic Relationships**: Observers can be added or removed at runtime
- **Broadcast Communication**: Subject broadcasts changes to all interested observers
- **Open/Closed Principle**: New observer types can be added without modifying the subject

## Design Principles Applied

- Program to interfaces, not implementations
- Strive for loosely coupled designs between objects that interact
- Classes should be open for extension but closed for modification