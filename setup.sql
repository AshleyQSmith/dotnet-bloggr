-- commented out because once you've created the table, it doesn't need to happen again unless you need to create a new one again

-- CREATE TABLE blogs (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(80) NOT NULL,
--   body VARCHAR(255),
--   description VARCHAR(255),
--   isPublished TINYINT NOT NULL,
--   PRIMARY KEY (id)
-- )


-- changing a table example:
-- ALTER TABLE blogs DROP description;


-- get all example
-- SELECT * FROM blogs;

-- CREATE TABLE tags(
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(20) NOT NULL,
--   PRIMARY KEY (id)
-- )


-- CREATE TABLE tagblogs(
--   id INT NOT NULL AUTO_INCREMENT,
--   blogId INT NOT NULL,
--   tagId INT NOT NULL,
--   PRIMARY KEY (id),
--   INDEX (blogId),

--   FOREIGN KEY(blogId)
--     REFERENCES blogs(id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (tagId)
--       REFERENCES tags(id)
--       ON DELETE CASCADE
-- )