-- 1. CREATE DATABASE
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DevTrack_Db')
    CREATE DATABASE DevTrack_Db;
GO
USE DevTrack_Db;
GO

-- 2. CREATE TABLE
CREATE TABLE TblUser (
	Id			INT				IDENTITY(1,1)	NOT NULL,
	Username	VARCHAR(100)	NOT NULL,
	Password	VARCHAR(255)	NOT NULL,
	Email		VARCHAR(100)	NULL,
	CONSTRAINT PK_User PRIMARY KEY (Id)
);
GO

CREATE TABLE Mistake (
	Id				INT				IDENTITY(1,1)	NOT NULL,
	UserId			INT				NOT NULL,
	Description		VARCHAR(255)	NOT NULL,
	OccurrenceCount	INT				NOT NULL,
	CONSTRAINT PK_Mistake PRIMARY KEY (Id)
);
GO

CREATE TABLE Reminder (
	Id			INT				IDENTITY(1,1)	NOT NULL,
	UserId		INT				NOT NULL,
	Message		VARCHAR(255)	NOT NULL,
	Time		TIME			NOT NULL,
	CONSTRAINT PK_Reminder PRIMARY KEY (Id)
);
GO

CREATE TABLE Gamification (
	Id		INT				NOT NULL,
	XP		INT				NOT NULL,
	Level	INT				NOT NULL,
	CONSTRAINT PK_Gamification PRIMARY KEY (Id)
);
GO

CREATE TABLE LogEntry (
	Id				INT				IDENTITY(1,1)	NOT NULL,
	UserId			INT				NOT NULL,
	Date			DATETIME		NOT NULL,
	WhatLearned		VARCHAR(255)	NOT NULL,
	Difficulties	VARCHAR(255)	NOT NULL,
	KeyTakeaways	VARCHAR(255)	NOT NULL,
	CONSTRAINT PK_LogEntry PRIMARY KEY (Id)
);
GO

CREATE TABLE Progress (
	Id			INT				NOT NULL,
	Percentage	INT				NOT NULL,
	CONSTRAINT PK_Progress PRIMARY KEY (Id)
);
GO

CREATE TABLE Analytics (
	Id					INT				NOT NULL,
	TotalHours			FLOAT			NOT NULL,
	MostProductiveTime	VARCHAR(100)	NOT NULL,
	ProgressTrend		VARCHAR(100)	NOT NULL,
	CONSTRAINT PK_Analytics PRIMARY KEY (Id)
);
GO

CREATE TABLE Badge (
	Id			INT				IDENTITY(1,1)	NOT NULL,
	Name		VARCHAR(100)	NOT NULL,
	Description	VARCHAR(255)	NOT NULL,
	Icon		VARCHAR(255)	NOT NULL,
	CONSTRAINT PK_Badge PRIMARY KEY (Id)
);
GO

CREATE TABLE UserBadge (
	UserId		INT				NOT NULL,
	BadgeId		INT				NOT NULL,
	EarnedDate	DATETIME		NOT NULL,
	CONSTRAINT PK_UserBadge PRIMARY KEY (UserId, BadgeId)
);
GO

CREATE TABLE Tag (
	Id		INT				IDENTITY(1,1)	NOT NULL,
	Name	VARCHAR(100)	NOT NULL,
	CONSTRAINT PK_Tag PRIMARY KEY (Id)
);
GO

CREATE TABLE LogEntryTag (
	LogEntryId	INT				NOT NULL,
	TagId		INT				NOT NULL,
	CONSTRAINT PK_LogEntryTag PRIMARY KEY (LogEntryId, TagId)
);
GO

-- 3. CREATE RELATIONSHIP
ALTER TABLE Mistake
	ADD CONSTRAINT FK_User_Mistake FOREIGN KEY (UserId) REFERENCES TblUser(Id);
GO

ALTER TABLE Reminder
	ADD CONSTRAINT FK_User_Reminder FOREIGN KEY (UserId) REFERENCES TblUser(Id);
GO

ALTER TABLE Gamification
	ADD CONSTRAINT FK_User_Gamification FOREIGN KEY (Id) REFERENCES TblUser(Id);
GO

ALTER TABLE LogEntry
	ADD CONSTRAINT FK_User_LogEntry FOREIGN KEY (UserId) REFERENCES TblUser(Id);
GO

ALTER TABLE Progress
	ADD CONSTRAINT FK_User_Progress FOREIGN KEY (Id) REFERENCES TblUser(Id);
GO

ALTER TABLE Analytics
	ADD CONSTRAINT FK_User_Analytics FOREIGN KEY (Id) REFERENCES TblUser(Id);
GO

ALTER TABLE LogEntryTag
	ADD
		CONSTRAINT FK_LogEntry_LogEntryTag FOREIGN KEY (LogEntryId) REFERENCES LogEntry(Id),
		CONSTRAINT FK_Tag_LogEntryTag FOREIGN KEY (TagId) REFERENCES Tag(Id);
GO

ALTER TABLE UserBadge
	ADD
		CONSTRAINT FK_User_UserBadge FOREIGN KEY (UserId) REFERENCES TblUser(Id),
		CONSTRAINT FK_Badge_UserBadge FOREIGN KEY (BadgeId) REFERENCES Badge(Id);
GO

---- 4. INSERT VIRTUAL DATA
INSERT INTO TblUser (Username, Password, Email) VALUES
('alice', 'Pass@123', 'alice@example.com'),
('bob', 'Secret@456', 'bob@example.com'),
('charlie', 'Qwerty@789', 'charlie@example.com');
GO

INSERT INTO Gamification (Id, XP, Level) VALUES
(1, 150, 2),
(2, 300, 4),
(3, 50, 1);
GO

INSERT INTO Progress (Id, Percentage) VALUES
(1, 45),
(2, 80),
(3, 10);
GO

INSERT INTO Analytics (Id, TotalHours, MostProductiveTime, ProgressTrend) VALUES
(1, 120.5, 'Morning', 'Upward'),
(2, 200.0, 'Afternoon', 'Stable'),
(3, 15.0, 'Evening', 'Declining');
GO

INSERT INTO Mistake (UserId, Description, OccurrenceCount) VALUES
(1, 'Forgot to push code to Git', 2),
(1, 'Missed daily standup meeting', 1),
(2, 'Introduced a bug in authentication module', 3),
(3, 'Used wrong dataset for analysis', 1);
GO

INSERT INTO Reminder (UserId, Message, Time) VALUES
(1, 'Review pull requests', '09:00'),
(2, 'Update project documentation', '14:00'),
(3, 'Refactor login feature', '16:30');
GO

INSERT INTO LogEntry (UserId, Date, WhatLearned, Difficulties, KeyTakeaways) VALUES
(1, '2025-08-01', 'Learned about async programming in C#', 'Understanding await/async flow', 'Practice with real API calls'),
(1, '2025-08-02', 'Explored Entity Framework migrations', 'Handling schema changes', 'Use Add-Migration carefully'),
(2, '2025-08-01', 'Improved SQL query performance', 'Index optimization', 'Use EXPLAIN for query analysis'),
(3, '2025-08-03', 'Studied React hooks', 'State management confusion', 'Use useReducer for complex state');
GO

INSERT INTO Tag (Name) VALUES
('Backend'),
('Frontend'),
('Database'),
('DevOps');
GO

INSERT INTO LogEntryTag (LogEntryId, TagId) VALUES
(1, 1), -- Async programming -> Backend
(2, 3), -- EF migrations -> Database
(3, 3), -- SQL performance -> Database
(4, 2); -- React hooks -> Frontend
GO

INSERT INTO Badge (Name, Description, Icon) VALUES
('Early Bird', 'Completed tasks before 9 AM', 'early_bird.png'),
('Night Owl', 'Worked after midnight', 'night_owl.png'),
('Bug Squasher', 'Fixed more than 10 bugs', 'bug_squasher.png');
GO

INSERT INTO UserBadge (UserId, BadgeId, EarnedDate) VALUES
(1, 1, '2025-07-20'),
(1, 3, '2025-07-25'),
(2, 2, '2025-08-01'),
(3, 3, '2025-08-03');
GO