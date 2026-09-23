# Domain Model

## User

### Properties

- Id
- Email
- PasswordHash
- GoogleId
- CreatedAt

### Relationships

- One User has one Profile.
- One User can have many Periods.
- One User can have many Achievements.
- One User can have many Events.

### Business Rules

- Email must be unique.
- Password must never be stored in plain text.
- A user can authenticate using email and password or Google.


## Profile

### Properties

- Id
- UserId
- Username
- DisplayName
- AvatarUrl
- Bio
- LastUsernameChangeAt

### Relationships

- One Profile belongs to one User.

### Business Rules

- Username must be unique.
- Username can be changed once after registration.
- After changing the username, the user must wait 14 days before changing it again.
- Avatar is optional.
- DisplayName does not have to be unique.


## Period

### Properties

- Id
- UserId
- Type
- Title
- StartDate
- EndDate
- Location
- Description
- CreatedAt

### Types

- Education
- Service
- Training
- Other

### Relationships

- One Period belongs to one User.

### Business Rules

- StartDate must be earlier than EndDate.
- A period can be future, current or completed.
- A user can have multiple periods.
- Progress and remaining time are calculated dynamically and are not stored in the database.


## Achievement

### Properties

- Id
- UserId
- Type
- Title
- Description
- IssuedAt
- CreatedAt

### Types

- Medal
- Award
- Certificate
- Education
- Other

### Relationships

- One Achievement belongs to one User.

### Business Rules

- Achievements can be public or private.
- Official verification is not implemented in the first version.
- Users can create, edit and delete their achievements.


## Event

### Properties

- Id
- UserId
- Type
- Title
- Description
- Date
- CreatedAt

### Types

- General
- Education
- Service
- Achievement
- Other

### Relationships

- One Event belongs to one User.

### Business Rules

- Events are displayed in the user's timeline.
- Users can create, edit and delete their events.