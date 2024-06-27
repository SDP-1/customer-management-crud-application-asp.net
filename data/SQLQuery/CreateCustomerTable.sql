CREATE TABLE customers (
  id INT NOT NULL PRIMARY KEY IDENTITY,
  firstname NVARCHAR(100) NOT NULL,
  lastname NVARCHAR(100) NOT NULL,
  email NVARCHAR(100) NOT NULL UNIQUE,
  phone NVARCHAR(100) NOT NULL,
  address NVARCHAR(100) NOT NULL,
  company NVARCHAR(100) NOT NULL,
  notes NVARCHAR(MAX) NOT NULL,
  created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);


INSERT INTO customers (firstname, lastname, email, phone, address, company, notes)
VALUES
('John', 'Doe', 'john.doe@example.com', '555-1234', '123 Elm St', 'Example Inc.', 'First customer'),
('Jane', 'Smith', 'jane.smith@example.com', '555-5678', '456 Oak St', 'Smith LLC', 'VIP customer'),
('Alice', 'Johnson', 'alice.johnson@example.com', '555-8765', '789 Pine St', 'Johnson & Co', 'Frequent buyer'),
('Bob', 'Brown', 'bob.brown@example.com', '555-4321', '321 Maple St', 'Brown Corp', 'Likes discounts'),
('Charlie', 'Davis', 'charlie.davis@example.com', '555-6789', '654 Birch St', 'Davis Enterprises', 'Referred by Jane'),
('Diana', 'Clark', 'diana.clark@example.com', '555-9876', '987 Cedar St', 'Clark Ltd', 'Prefers email communication'),
('Evan', 'Miller', 'evan.miller@example.com', '555-1111', '111 Spruce St', 'Miller Group', 'Interested in new products'),
('Fiona', 'Wilson', 'fiona.wilson@example.com', '555-2222', '222 Aspen St', 'Wilson Brothers', 'Good feedback'),
('George', 'Moore', 'george.moore@example.com', '555-3333', '333 Willow St', 'Moore Partners', 'Recently moved'),
('Hannah', 'Taylor', 'hannah.taylor@example.com', '555-4444', '444 Redwood St', 'Taylor Innovations', 'High-value customer');
