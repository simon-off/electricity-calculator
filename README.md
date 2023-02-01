# __⚡ Electricity Calculator ⚡__

[![.NET](https://github.com/simon-off/electricity-calculator/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/simon-off/electricity-calculator/actions/workflows/dotnet.yml)

Simple Calculator app made with [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) & [Pico.css](https://picocss.com/). Part of course submission for _C# introduction_ at _ECUtbildning_ 2023.

Preview on Netlify: [Electricity Calculator](https://electricitycalculator.netlify.app/)

---

## __About this app__

_- An online calculator that helps you easily estimate your electricity consumption and costs_

With this app we tried to create an electricity calculator that is simple and easy to use. We want to make sure you have the information you need to make informed decisions about your energy consumption. Each items cost is calculated by multiplying the usage time, wattage and electricity price per kWh.

### __How to use this app__

1. Enter your electricity cost per kWh, in the `(currency)/kWh` field.
2. Enter the wattage of each item, in the `WATTAGE` field.
3. Enter the usage time of each item, in the `USAGE` field.
4. You can choose to enter usage time in either minutes or hours: `M/H`.
5. The calculated result for each item is shown in the `KWH` and `COST` fields.
6. The calculated results for all items is shown in the `Total kWH` and `Total Cost` fields.
7. You can view the total cost and kWh per day, month or year: `D/M/Y`

---

## 💿 __Running the app locally:__

❗ Make sure you have the latest version of the [.NET sdk](https://dotnet.microsoft.com/en-us/download/dotnet) installed ❗

Clone this repo on your local machine:

```sh
$ git clone https://github.com/simon-off/electricity-calculator.git
$ cd electricity-calculator/ElectricityCalculator
```

Start your local app instance by running:

```sh
$ dotnet run
```

OR if you want hot reloading:

```sh
$ dotnet watch
```

---

Made with love by _[Simon](https://github.com/simon-off)_ & _[Daniel](https://github.com/DanielAndersson31)_
