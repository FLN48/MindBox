---------------------------------------------------------------------------------------- ������ ��������
CREATE TABLE PRODUCTS(
PROD_ID INT PRIMARY KEY IDENTITY, 
PROD_NAME VARCHAR(100) NOT NULL);

CREATE TABLE CATEGORY(
CATEG_ID INT PRIMARY KEY IDENTITY,
CATEG_NAME VARCHAR(100) NOT NULL);

CREATE TABLE PRODUCT_CATEGORY(
F_PROD_ID INT NOT NULL,
F_CATEG_ID INT NOT NULL,
FOREIGN KEY(F_PROD_ID) REFERENCES Products(PROD_ID) ON DELETE CASCADE,
FOREIGN KEY(F_CATEG_ID) REFERENCES Category(CATEG_ID) ON DELETE CASCADE);

CREATE UNIQUE INDEX IND_PRODUCT_CATEGORY ON PRODUCT_CATEGORY(F_PROD_ID, F_CATEG_ID);
---------------------------------------------------------------------------------------- ���������

INSERT INTO PRODUCTS VALUES('���'), ('���'), ('��������');
INSERT INTO CATEGORY VALUES('������'), ('�������� �������');
INSERT INTO PRODUCT_CATEGORY VALUES(1, 1), (2, 1), (2, 2);
---------------------------------------------------------------------------------------- �����

SELECT P.PROD_NAME AS '�������', C.CATEG_NAME AS '���������'
FROM PRODUCTS P
LEFT JOIN PRODUCT_CATEGORY P_C ON P.PROD_ID = P_C.F_PROD_ID
LEFT JOIN CATEGORY C ON C.CATEG_ID = P_C.F_CATEG_ID
ORDER BY P.PROD_NAME;