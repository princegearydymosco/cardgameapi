# Card Game API

This is a RESTful API for managing a deck of cards. It allows you to create new decks, shuffle decks, and draw cards from decks.

## Getting Started

### Usage

1. Run the API using the following command:


This will start the API server on `http://localhost:xxxx`.

2. Navigate to `http://localhost:xxxx/swagger` to view the Swagger UI, which provides an interactive documentation for the API endpoints.

From the Swagger UI, you can test the API by sending requests to each endpoint. You can also view the request and response schemas for each endpoint.

## API Endpoints

### `POST /deck`

Creates a new deck of cards.

**Query Parameters**

- `shuffled` (optional): If set to `true`, the deck will be shuffled. Default is `false`.
- `cards` (optional): A comma-separated list of card codes to include in the deck. For example: `AS,KC,QH`.

### `GET /deck/{deckId}`

Returns the details of a specific deck.

**Path Parameters**

- `deckId`: The unique identifier of the deck.

### `GET /deck/{deckId}/draw`

Draws one or more cards from a deck.

**Path Parameters**

- `deckId`: The unique identifier of the deck.

**Query Parameters**

- `count` (optional): The number of cards to draw. Default is `1`.