# API

## Authentication

### Register

```http
POST /api/auth/register
```

Creates a new user account.

### Login

```http
POST /api/auth/login
```

Authenticates a user and returns an access token.

### Refresh Token

```http
POST /api/auth/refresh
```

Generates a new access token using a refresh token.

### Logout

```http
POST /api/auth/logout
```

Revokes the current refresh token.

### Google Login

```http
POST /api/auth/google
```

Authenticates a user using Google.

## Profile

### Get My Profile

```http
GET /api/profile
```

Returns the authenticated user's profile.

### Update My Profile

```http
PUT /api/profile
```

Updates the authenticated user's profile.

### Get Public Profile

```http
GET /api/users/{username}
```

Returns the public profile of a user according to their privacy settings.

## Privacy

### Get Privacy Settings

```http
GET /api/privacy
```

Returns the authenticated user's privacy settings.

### Update Privacy Settings

```http
PUT /api/privacy
```

Updates the authenticated user's privacy settings.

## Periods

### Get My Periods

```http
GET /api/periods
```

Returns all periods belonging to the authenticated user.

### Get Period

```http
GET /api/periods/{id}
```

Returns a specific period.

### Create Period

```http
POST /api/periods
```

Creates a new period.

### Update Period

```http
PUT /api/periods/{id}
```

Updates an existing period.

### Delete Period

```http
DELETE /api/periods/{id}
```

Deletes a period.

## Progress

### Get Current Progress

```http
GET /api/progress
```

Returns calculated progress and remaining time for the user's current period.

## Achievements

### Get My Achievements

```http
GET /api/achievements
```

Returns all achievements belonging to the authenticated user.

### Get Achievement

```http
GET /api/achievements/{id}
```

Returns a specific achievement.

### Create Achievement

```http
POST /api/achievements
```

Creates a new achievement.

### Update Achievement

```http
PUT /api/achievements/{id}
```

Updates an existing achievement.

### Delete Achievement

```http
DELETE /api/achievements/{id}
```

Deletes an achievement.

## Events

### Get My Events

```http
GET /api/events
```

Returns all events belonging to the authenticated user.

### Get Event

```http
GET /api/events/{id}
```

Returns a specific event.

### Create Event

```http
POST /api/events
```

Creates a new event.

### Update Event

```http
PUT /api/events/{id}
```

Updates an existing event.

### Delete Event

```http
DELETE /api/events/{id}
```

Deletes an event.
