# W9D2_task

# Blogging Platform - Post and Comment Services

This is a blogging platform with two services:

- **Post Service**: Manages blog posts.
- **Comment Service**: Manages comments associated with blog posts.

The services communicate with each other to validate `postId` when adding a comment.

## Features

- **Post Service**:
  - Create a new blog post
  - Retrieve all blog posts
  - Retrieve a specific blog post by its ID
  
- **Comment Service**:
  - Add a comment to a blog post
  - Get all comments for a specific blog post
  
Both services are Dockerized and can be run using Docker Compose.

## Technologies

- **ASP.NET Core**: Framework for building the APIs.
- **HTTP Client**: Used by the `CommentService` to validate `postId` against the `PostService`.
- **Docker**: For containerization and easy deployment.
- **JSON**: Used for request and response bodies.
- **Guid**: Used for unique post and comment identification.

## Setup and Installation

### Prerequisites

- Docker (if you're running the application in containers)
- .NET SDK 9.0 or higher

### Steps

1. **Clone the repository**:

   ```bash
   git clone https://github.com/your-username/blogging-platform.git
   cd blogging-platform
