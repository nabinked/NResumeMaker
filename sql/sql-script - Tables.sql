DROP SCHEMA IF EXISTS core CASCADE;
CREATE SCHEMA core;

DROP TABLE IF EXISTS core.users;
CREATE TABLE IF NOT EXISTS core.users (
	id 					bigserial PRIMARY KEY,
	user_name			varchar(500) UNIQUE NOT NULL,
	password_hash		varchar NOT NULL,
	email				varchar(150) UNIQUE NOT NULL
	);
INSERT INTO core.users (user_name, password_hash, email) VALUES('nabinked','nabinkarkithapa','nabin@outlook.com');
DROP TABLE IF EXISTS core.genders;
CREATE TABLE IF NOT EXISTS core.genders (
	id 		int PRIMARY KEY,
	gender_name	varchar(16) UNIQUE NOT NULL
	);
	
INSERT INTO core.genders (id, gender_name) VALUES(1, 'Male');
INSERT INTO core.genders (id, gender_name) VALUES(2, 'Female');
INSERT INTO core.genders (id, gender_name) VALUES(3, 'Other Gender');

DROP TABLE IF EXISTS core.driver_licenses;
CREATE TABLE IF NOT EXISTS core.driver_licenses (
	id 		int PRIMARY KEY,
	licence_type	varchar(16) UNIQUE NOT NULL
	);
	
INSERT INTO core.driver_licenses (id, licence_type) VALUES(1, 'MotorCycles');
INSERT INTO core.driver_licenses (id, licence_type) VALUES(2, 'Cars');
INSERT INTO core.driver_licenses (id, licence_type) VALUES(3, 'Medium');
INSERT INTO core.driver_licenses (id, licence_type) VALUES(4, 'Heavy');

DROP TABLE IF EXISTS core.marital_statuses;
CREATE TABLE IF NOT EXISTS core.marital_statuses(
	id 		int PRIMARY KEY,
	marital_status	varchar(16) UNIQUE NOT NULL
	);
	
INSERT INTO core.marital_statuses (id, marital_status) VALUES(1, 'Single');
INSERT INTO core.marital_statuses (id, marital_status) VALUES(2, 'Married');

DROP TABLE IF EXISTS core.contact_details;
CREATE TABLE IF NOT EXISTS core.contact_details(
	id					bigserial PRIMARY KEY,
	user_id				bigint	NOT NULL REFERENCES core.users (id),
	first_name			varchar(50) NOT NULL,
	last_name			varchar(50) NOT NULL,
	street_address		varchar(100) NOT NULL,
	suburb				varchar(100) NOT NULL,
	state				varchar(100) NOT NULL,
	country				varchar(100) NOT NULL,
	telephone_num		varchar,
	mobile_num			varchar NOT NULL,		
	github_url			varchar,
	facebook_url		varchar,
	linkedin_url		varchar,
	twitter_url			varchar
	);

DROP TABLE IF EXISTS core.summaries;
CREATE TABLE IF NOT EXISTS core.summaries(
	id			bigserial PRIMARY KEY,
	user_id			bigint	NOT NULL REFERENCES core.users (id),
	summary_text		varchar NOT NULL	
);

DROP TABLE IF EXISTS core.objectives;
CREATE TABLE IF NOT EXISTS core.objectives(
	id			bigserial PRIMARY KEY,
	user_id			bigint	NOT NULL REFERENCES core.users (id),
	objective_text		varchar NOT NULL	
);

DROP TABLE IF EXISTS core.educations;
CREATE TABLE IF NOT EXISTS core.educations(
	id			bigserial PRIMARY KEY,
	user_id			bigint	NOT NULL REFERENCES core.users (id),
	education_degree	varchar(500) NOT NULL,
	school			varchar	(500) NOT NULL,
	year_of_completion	int NOT NULL,
	description		varchar(500)
);

DROP TABLE IF EXISTS core.experiences;
CREATE TABLE IF NOT EXISTS core.experiences(
	id			bigserial PRIMARY KEY,
	user_id			bigint	NOT NULL REFERENCES core.users (id),
	job_title		varchar(250) NOT NULL,
	organization_name	varchar	(250) NOT NULL,
	organization_city	varchar(250) NOT NULL,
	organization_country	varchar(250) NOT NULL,
	from_year				int,
	to_year					int,
	duration				int,
	description		varchar
);

DROP TABLE IF EXISTS core.job_descriptions;
CREATE TABLE IF NOT EXISTS core.job_descriptions(
	id					bigserial PRIMARY KEY,
	experience_id		bigint NOT NULL REFERENCES core.experiences(id),
	description		varchar NOT NULL
);

DROP TABLE IF EXISTS core.key_accomplishments;
CREATE TABLE IF NOT EXISTS core.key_accomplishments(
	id					bigserial PRIMARY KEY,
	experience_id		bigint NOT NULL REFERENCES core.experiences(id),
	accomplishment	varchar NOT NULL
);

DROP TABLE IF EXISTS core.skills;
CREATE TABLE IF NOT EXISTS core.skills(
	id					bigserial PRIMARY KEY,
	skill_name			varchar(250) NOT NULL,
	proficiency			int NOT NULL CHECK (proficiency > 0 AND proficiency < 6),
    user_id             bigint REFERENCES core.users(id)
);

DROP TABLE IF EXISTS core.week_days;
CREATE TABLE IF NOT EXISTS core.week_days(
	id					int PRIMARY KEY,
	week_day			varchar(20) NOT NULL
);

INSERT INTO core.week_days (id, week_day) VALUES(1, 'Sunday');
INSERT INTO core.week_days (id, week_day) VALUES(2, 'Monday');
INSERT INTO core.week_days (id, week_day) VALUES(3, 'Tuesday');
INSERT INTO core.week_days (id, week_day) VALUES(4, 'Wednesday');
INSERT INTO core.week_days (id, week_day) VALUES(5, 'Thursday');
INSERT INTO core.week_days (id, week_day) VALUES(6, 'Friday');
INSERT INTO core.week_days (id, week_day) VALUES(7, 'Saturday');

DROP TABLE IF EXISTS core.availablities;
CREATE TABLE IF NOT EXISTS core.availablities(
	id					int PRIMARY KEY,
	user_id				bigint NOT NULL REFERENCES core.users(id),
	week_day_id			int NOT NULL REFERENCES core.week_days(id),
	start_time			timestamp NOT NULL,
	end_time			timestamp NOT NULL
);
DROP TABLE IF EXISTS core.personal_details;
CREATE TABLE IF NOT EXISTS core.personal_details(	
	id					bigserial PRIMARY KEY,
	user_id				bigint	NOT NULL REFERENCES core.users (id),
	date_of_birth		date NOT NULL,
	gender_id			int NOT NULL REFERENCES core.genders(id),
	driver_licence_id	int NOT NULL REFERENCES core.driver_licenses(id),
	nationality			varchar(200) NOT NULL,
	religion			varchar(50),
	languages_spoken	varchar NOT NULL
);

DROP TABLE IF EXISTS core.other_details;
CREATE TABLE IF NOT EXISTS core.other_details(
	id					bigserial PRIMARY KEY,
	user_id				bigint NOT NULL REFERENCES core.users(id),
	detail_title		varchar	NOT NULL,
	detail_value		varchar NOT NULL
)

DROP TABLE IF EXISTS core.profile_hits;
CREATE TABLE IF NOT EXISTS core.profile_hits(
	id 					bigserial 	PRIMARY KEY,
	user_id				bigint	NOT NULL REFERENCES core.users (id),
	hit_count			bigint NOT NULL
);



