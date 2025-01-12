CREATE TABLE Users (
    user_id INT IDENTITY(1,1) NOT NULL,
    branch_id INT NOT NULL,
    username VARCHAR(50) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    is_active BIT DEFAULT 1,
    CONSTRAINT PK_Users PRIMARY KEY (user_id)
);


CREATE TABLE Branches (
    branch_id INT IDENTITY(1,1) NOT NULL,
    branch_name VARCHAR(100) NOT NULL,
    branch_address VARCHAR(200) NOT NULL,
    CONSTRAINT PK_Branches PRIMARY KEY (branch_id)
);


CREATE TABLE Clients (
    client_id INT IDENTITY(1,1) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    document_id VARCHAR(20) NOT NULL,
    phone_number VARCHAR(15) NULL,
    email VARCHAR(100) NULL,
    CONSTRAINT PK_Clients PRIMARY KEY (client_id)
);


CREATE TABLE Bills (
    bill_id INT IDENTITY(1,1) NOT NULL,
    client_id INT NOT NULL,
    branch_id INT NOT NULL,
    amount_due DECIMAL(10,2) NOT NULL,
    amount_paid DECIMAL(10,2) DEFAULT 0,
    is_paid BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME NULL,
    CONSTRAINT PK_Bills PRIMARY KEY (bill_id),
    CONSTRAINT FK_Bills_Clients FOREIGN KEY (client_id) REFERENCES Clients(client_id),
    CONSTRAINT FK_Bills_Branches FOREIGN KEY (branch_id) REFERENCES Branches(branch_id)
);


CREATE TABLE Cash_Transactions (
    transaction_id INT IDENTITY(1,1) NOT NULL,
    user_id INT NOT NULL,
    branch_id INT NOT NULL,
    transaction_type VARCHAR(10) NOT NULL, -- IN (entrada) o OUT (salida)
    amount DECIMAL(10,2) NOT NULL,
    notes VARCHAR(200) NULL,
    created_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_Cash_Transactions PRIMARY KEY (transaction_id),
    CONSTRAINT FK_Cash_Transactions_Users FOREIGN KEY (user_id) REFERENCES Users(user_id),
    CONSTRAINT FK_Cash_Transactions_Branches FOREIGN KEY (branch_id) REFERENCES Branches(branch_id)
);


CREATE TABLE Cash_Daily (
    daily_id INT IDENTITY(1,1) NOT NULL,
    user_id INT NOT NULL,
    branch_id INT NOT NULL,
    date DATE NOT NULL,
    initial_amount DECIMAL(10,2) NOT NULL,
    total_in DECIMAL(10,2) DEFAULT 0,
    total_out DECIMAL(10,2) DEFAULT 0,
    closing_amount DECIMAL(10,2) DEFAULT 0,
    is_closed BIT DEFAULT 0,
    CONSTRAINT PK_Cash_Daily PRIMARY KEY (daily_id),
    CONSTRAINT FK_Cash_Daily_Users FOREIGN KEY (user_id) REFERENCES Users(user_id),
    CONSTRAINT FK_Cash_Daily_Branches FOREIGN KEY (branch_id) REFERENCES Branches(branch_id)
);


INSERT INTO Users (branch_id, username, password_hash, is_active)
VALUES 
(1, 'admin', 'hashed_password1', 1),
(1, 'cashier1', 'hashed_password2', 1);


INSERT INTO Branches (branch_name, branch_address)
VALUES 
('Sucursal Central', 'Av. Principal #123'),
('Sucursal Norte', 'Calle Norte #456');


INSERT INTO Clients (full_name, document_id, phone_number, email)
VALUES 
('Juan Pérez', '001-1234567-8', '8091234567', 'juanperez@example.com'),
('María Gómez', '002-7654321-9', '8297654321', 'mariagomez@example.com');
INSERT INTO Users (branch_id, username, password_hash, is_active)
VALUES (1, 'admin', HASHBYTES('SHA2_256', 'admin123'), 1);