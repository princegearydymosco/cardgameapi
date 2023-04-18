# Card Game API

This is a RESTful API for managing a deck of cards. It allows you to create new decks, shuffle decks, and draw cards from decks.

## Getting Started

### Prerequisites

To run this project on your local machine, you will need to have the following tools installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Installation

1. Clone this repository to your local machine:

git clone https://github.com/princegearydymosco/cardgameapi.git

### How To Use

1. Open the solution file in Visual Studio.

2. Build the solution.

This will start the API server on `http://localhost:xxxx`.

3. Navigate to `http://localhost:xxxx/swagger` to view the Swagger UI, which provides an interactive documentation for the API endpoints.

From the Swagger UI, you can test the API by sending requests to each endpoint. You can also view the request and response schemas for each endpoint.

## API Endpoints

### `POST /Deck/api/deck`

Creates a new deck of cards.

**Query Parameters**

- `shuffled` (optional): If set to `true`, the deck will be shuffled. Default is `false`.
- `cards` (optional): A comma-separated list of card codes to include in the deck. For example: `AS,KC,QH`.

### `GET /Deck/api/deck/{deckId}`

Returns the details of a specific deck.

**Path Parameters**

- `deckId`: The unique identifier of the deck.

### `GET /Deck/api/deck/{deckId}/draw`

Draws one or more cards from a deck.

**Path Parameters**

- `deckId`: The unique identifier of the deck.

**Query Parameters**

- `count` (optional): The number of cards to draw. Default is `1`.