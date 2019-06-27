# Pokemon Viewer
Pokemon viewer is a .Net core 2.1 web application which shows [Pokemon](https://en.wikipedia.org/wiki/Pokémon) details.


## Installation
### Prerequisites

* .Net core 2.1 SDK | Which you can download and install from [here](https://dotnet.microsoft.com/download/dotnet-core/2.1)

### Execution
1. Clone this repository
```bash
> git clone https://github.com/s3651907/Pokemon_API.git
```
2. cd into root folder
```bash
> cd Pokemon_API
```
3. Start the web server
```bash
> dotnet run -p .\PokemonViewer\
```
4. Open web browser and browse flowing link
```
http://localhost:5000
```
##### Number of Pokemons per page can be configured by changing 'ResultSize' value in  \PokemonViewer\appsettings.json
```
"Pagination": {
    "ResultSize": 10
```
###### * Default size of 10 is assigned in application if failed to load.

### License
* [MIT](https://choosealicense.com/licenses/mit/)

#
