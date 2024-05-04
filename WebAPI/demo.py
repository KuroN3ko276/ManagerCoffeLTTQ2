import pyodbc
import flask
from flask import Flask, request, jsonify

con_str = (
    "Driver={SQL Server};"
    "Server=CAU-CHINH\SQLEXPRESS;"
    "Database=QLCoffeLTTQ;"
    "Trusted_Connection=yes;"
)

try:
    conn = pyodbc.connect(con_str)
    app = flask.Flask(__name__)

    # get all food
    @app.route('/food/getAllFood', methods=['GET'])
    def getAllFood():
        cursor = conn.cursor()
        sql = 'select * from Food'
        cursor.execute(sql)
        results = [] # kết quả
        keys = [] #
        for i in cursor.description: 
            keys.append(i[0])
        for i in cursor.fetchall():
            results.append(dict(zip(keys,i)))
        resp = flask.jsonify(results)
        resp.status_code = 200
        return resp        
    # get Account list
    @app.route('/account/getAllAccount', methods=['GET'])
    def getAllAccount():
        cursor = conn.cursor()
        sql = 'select * from Account'
        cursor.execute(sql)
        results = [] # kết quả
        keys = [] #
        for i in cursor.description: 
            keys.append(i[0])
        for i in cursor.fetchall():
            results.append(dict(zip(keys,i)))
        resp = flask.jsonify(results)
        resp.status_code = 200
        return resp  
    #Insert Food
    @app.route('/food/insert', methods=['POST'])
    def insertFood():
        try:
            foodName = flask.request.json.get('name')
            idCategory = flask.request.json.get('idCategory')
            price = flask.request.json.get('price')
        
            # Kiểm tra xem món ăn có tồn tại trong cơ sở dữ liệu hay không
            cursor = conn.cursor()
            sql_check = ('SELECT COUNT(*) FROM food WHERE name = ?')
            cursor.execute(sql_check, (foodName,))
            result = cursor.fetchone()[0]
            
            if result > 0:
                return flask.jsonify({"mess": "Đã có món này"})
            else:
                # Thêm món ăn mới vào cơ sở dữ liệu
                sql = 'INSERT INTO food(name, idcategory, price) VALUES (?, ?, ?)'
                data = (foodName, idCategory, price)
                cursor.execute(sql, data)
                conn.commit()
                return flask.jsonify({"mess": "Thành công"})
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    #Edit Food
    @app.route('/food/edit',methods = ['PUT'])
    def EditFood():
        try:
            foodName = flask.request.json.get('name')
            idCategory = flask.request.json.get('idCategory')
            price = flask.request.json.get('price')
            idFood = flask.request.json.get('id')
            cursor = conn.cursor()
            sql_check = 'SELECT COUNT(*) FROM Food WHERE name = ?'
            cursor.execute(sql_check, (foodName,))
            result = cursor.fetchone()[0]
            
            if result > 0:
                # Nếu danh mục đã tồn tại, trả về thông báo tương ứng
                return flask.jsonify({"mess": "Đã có món này"})
            else:
                sql = 'Update food set name = ?, idCategory = ?, price = ? where id = ?'
                data = (foodName,idCategory,price,idFood)
                cursor.execute(sql, data)
                conn.commit()
                resp = flask.jsonify({"mess": "Thành công"})
                resp.status_code = 200
                return resp
        except:
            return flask.jsonify({"mess": str(e)})
    # insert category
    @app.route('/category/insertCategory', methods=['POST'])
    def insertCategory():
        try:
            nameCategory = flask.request.json.get('name')
            # Kiểm tra xem danh mục đã tồn tại hay chưa
            cursor = conn.cursor()
            sql_check = 'SELECT COUNT(*) FROM FoodCategory WHERE name = ?'
            cursor.execute(sql_check, (nameCategory,))
            result = cursor.fetchone()[0]
            
            if result > 0:
                # Nếu danh mục đã tồn tại, trả về thông báo tương ứng
                return flask.jsonify({"mess": "Đã có danh mục này"})
            else:
                # Nếu danh mục chưa tồn tại, thêm mới vào cơ sở dữ liệu
                sql_insert = 'INSERT INTO FoodCategory (name) VALUES (?)'
                cursor.execute(sql_insert, (nameCategory,))
                conn.commit()
                return flask.jsonify({"mess": "Thành công"})
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    #EditCategory
    @app.route('/category/edit',methods = ['PUT'])
    def EditCategory():
        try:
            categoryName = flask.request.json.get('name')
            idCategory = flask.request.json.get('id')
            cursor = conn.cursor()
            sql_check = 'SELECT COUNT(*) FROM FoodCategory WHERE name = ?'
            cursor.execute(sql_check, (categoryName,))
            result = cursor.fetchone()[0]
            
            if result > 0:
                # Nếu danh mục đã tồn tại, trả về thông báo tương ứng
                return flask.jsonify({"mess": "Đã có danh mục này"})
            else:
                sql = 'Update foodcategory set Name = ? where id = ? '
                data = (categoryName,idCategory)
                cursor.execute(sql, data)
                conn.commit()
                resp = flask.jsonify({"mess": "Thành công"})
                resp.status_code = 200
                return resp
        except:
            return flask.jsonify({"mess": str(e)})
    #Delete Category
    @app.route('/category/delete',methods = ['DELETE'])
    def DeleteCategory():
        try:
            categoryName = flask.request.args.get('name')
            idCategory = flask.request.args.get('id')
            cursor = conn.cursor()
            sql_check = 'SELECT COUNT(*) FROM Food WHERE idCategory = ?'
            cursor.execute(sql_check, (idCategory,))
            result = cursor.fetchone()[0]
            
            if result > 0:
                # Nếu danh mục đã tồn tại, trả về thông báo tương ứng
                return flask.jsonify({"mess": "Danh mục này đã có món"})
            else:
                sql = 'Delete from foodcategory Where id = ? AND name = ?'
                data = (idCategory,categoryName)
                cursor.execute(sql, data)
                conn.commit()
                resp = flask.jsonify({"mess": "Thành công"})
                resp.status_code = 200
                return resp
        except:
            return flask.jsonify({"mess": str(e)})
    # Insert Bill
    @app.route('/bill/insert', methods=['POST'])
    def insertBill():
        try:
            idTable = flask.request.json.get('idTable')
            cursor = conn.cursor()
            sql = 'exec USP_InsertBill @idTable = ?'
            data = (idTable,)
            cursor.execute(sql, data)
            conn.commit()
            resp = flask.jsonify({"mess": "Thành công"})
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})

    # Insert Bill Info
    @app.route('/billInfo/insert', methods=['POST'])
    def insertBillInfo():
        try:
            idBill = flask.request.json.get('idBill')
            idFood = flask.request.json.get('idFood')
            count = flask.request.json.get('foodCount')       
            cursor = conn.cursor()
            sql = 'exec USP_InsertBillInfo @idBill = ?, @idFood = ?, @count = ?'
            data = (idBill, idFood, count)
            cursor.execute(sql, data)
            conn.commit()
            resp = flask.jsonify({"mess": "Thành công"})
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
        
    #Get Account By UserName
    @app.route('/account/getaccountbyusername', methods = ['GET'])
    def getAccountByUserName():
        try:
            username = flask.request.json.get('UserName')
            cursor = conn.cursor()
            sql = "exec USP_GetAccountByUserName @username = ?"
            data = (username,)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
            
    #Get List Bill By Date
    @app.route('/bill/getbillbydate', methods = ['GET'])
    def getBillByDate():
        try:
            checkIn = flask.request.args.get('checkIn')
            checkOut = flask.request.args.get('checkOut')
            cursor = conn.cursor()
            sql = "exec USP_GetListBillByDate @checkIn = ?, @checkOut = ?"
            data = (checkIn,checkOut)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #Get List Bill By Date And Page 
    @app.route('/bill/getbillbydateandpage', methods = ['GET'])
    def getBillByDateAndPage():
        try:
            checkIn = flask.request.json.get('checkIn')
            checkOut = flask.request.json.get('checkOut')
            page = flask.request.json.get('page')
            cursor = conn.cursor()
            sql = "exec USP_GetListBillByDateAndPage @checkIn = ?, @checkOut =?, @page =?"
            data = (checkIn,checkOut,page)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #GetBillByDateForReport
    @app.route('/bill/getbillbydateforreport', methods = ['GET'])
    def getBillByDateForReport():
        try:
            checkIn = flask.request.json.get('checkIn')
            checkOut = flask.request.json.get('checkOut')
            cursor = conn.cursor()
            sql = "exec USP_GetListBillByDateForReport @checkIn = ?, @checkOut = ?"
            data = (checkIn,checkOut)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #GetNumBillByDate
    @app.route('/bill/getnumbillbydate', methods = ['GET'])
    def getNumBillByDate():
        try:
            checkIn = flask.request.json.get('checkIn')
            checkOut = flask.request.json.get('checkOut')
            cursor = conn.cursor()
            sql = "exec USP_GetListBillByDate @checkIn = ?, @checkOut = ?"
            data = (checkIn,checkOut)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #GetBillByTableID
    @app.route('/bill/getnumbillbytableid', methods = ['GET'])
    def getNumBillByTableId():
        try:
            tableId = flask.request.json.get('idTable')
            cursor = conn.cursor()
            sql = "SELECT * FROM dbo.Bill WHERE idTable = ? AND status = 0"
            data = (tableId,)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #GetMaxBillID
    @app.route('/bill/getmaxbillid', methods = ['GET'])
    def getMaxBillID():
        try:
            cursor = conn.cursor()
            sql = "SELECT MAX(id) FROM dbo.Bill"
            cursor.execute(sql)
            max_id = cursor.fetchone()[0]
            resp = flask.jsonify({"max_id": max_id})
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #CheckOutBill
    @app.route('/bill/checkout', methods = ['PUT'])
    def checkoutBill():
        try:
            cursor = conn.cursor()
            discount = flask.request.json.get('discount')
            totalPrice = flask.request.json.get('totalPrice')
            id = flask.request.json.get('id')         
            sql = "Update dbo.Bill Set status = 1, DateCheckOut = GETDATE(), discount = ?, totalPrice = ? where id = ?"
            data = (discount, totalPrice, id)
            cursor.execute(sql, data)
            conn.commit()
            resp = flask.jsonify({"mess": "Thành công"})
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #GetTableList
    @app.route('/table/gettablelist', methods = ['GET'])
    def getTableList():
        try:
            cursor = conn.cursor()
            sql = "exec USP_GetTableList"
            cursor.execute(sql)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #Login
    @app.route('/account/login', methods = ['GET'])
    def loginAccount():
        try:
            userName = flask.request.json.get('UserName')
            passWord = flask.request.json.get('PassWord')
            cursor = conn.cursor()
            sql = "exec USP_Login @username = ? , @password = ?"
            data = (userName, passWord)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #SwitchTable
    @app.route('/table/switchtable', methods=['PUT'])
    def switchTable():
        try:
            idTable1 = flask.request.json.get('idTable1')
            idTable2 = flask.request.json.get('idTable2')
            cursor = conn.cursor()
            sql = 'exec USP_SwitchTabel @idTable1 = ?, @idTable2 = ?'
            data = (idTable1, idTable2)
            cursor.execute(sql, data)
            conn.commit()
            resp = flask.jsonify({"mess": "Thành công"})
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #Update Account
    @app.route('/account/updateaccount', methods=['PUT'])
    def updateAccount():
        try:
            username = flask.request.json.get('UserName')
            displayname = flask.request.json.get('DisplayName')
            password = flask.request.json.get('PassWord')
            newpass = flask.request.json.get('NewPassword')        
            cursor = conn.cursor()
            sql = "exec USP_UpdateAccount @userName = ?, @displayName = ?, @password = ?, @newPassword = ?"
            data = (username, displayname, password, newpass)
            cursor.execute(sql, data)
            conn.commit()
            resp = flask.jsonify({"mess": "Thành công"})
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    # Get BillInfo
    @app.route('/bill/getbillinfo', methods=['GET'])
    def getBillInfo():
        try:
            idBill = flask.request.json.get('id')
            cursor = conn.cursor()
            sql = "SELECT * FROM dbo.BillInfo WHERE idBill = ?"
            data = (idBill,)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})

    #GetListCategory
    @app.route('/category/getlistcategory', methods=['GET'])
    def getListCategory():
        try:
            cursor = conn.cursor()
            sql = "SELECT * FROM dbo.FoodCategory"
            cursor.execute(sql)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
        
    #GetListMenuByTable
    @app.route('/menu/getlistmenubytable', methods=['GET'])
    def getListMenuByTable():
        try:
            idTable = flask.request.json.get('idTable')
            cursor = conn.cursor()
            sql = "SELECT f.name, bi.count, f.price, f.price* bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status=0 AND b.idTable = ?"
            data = (idTable,)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    #GetFoodByCategoryID
    @app.route('/food/getlistfoodbycategory', methods=['GET'])
    def getListFoodByCategory():
        try:
            idCategory = flask.request.json.get('idCategory')
            cursor = conn.cursor()
            sql = "select * from food where idCategory = ?"
            data = (idCategory,)
            cursor.execute(sql, data)
            results = []
            keys = [i[0] for i in cursor.description]
            for row in cursor.fetchall():
                results.append(dict(zip(keys, row)))
            resp = flask.jsonify(results)
            resp.status_code = 200
            return resp
        except Exception as e:
            return flask.jsonify({"mess": str(e)})
    
    if __name__ == '__main__':
        app.run(port=3333)

except Exception as e:
    print("Thất bại")

# import pyodbc
# import flask

# con_str = (
#     "Driver={SQL Server};"
#     "Server=KURON3KO\HAIDANG;"
#     "Database=QLCoffeLTTQ;"
#     "Trusted_Connection=yes;"
# )

# try:
#     conn = pyodbc.connect(con_str)
#     app = flask.Flask(__name__)

#     # Insert Bill
#     @app.route('/bill/insert', methods=['POST'])
#     def insertBill():
#         try:
#             idTable = flask.request.json.get('idTable')
#             cursor = conn.cursor()
#             sql = 'exec USP_InsertBill @idTable = ?'
#             data = (idTable,)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})

#     # Insert Bill Info
#     @app.route('/billInfo/insert', methods=['POST'])
#     def insertBillInfo():
#         try:
#             idBill = flask.request.json.get('idBill')
#             idFood = flask.request.json.get('idFood')
#             count = flask.request.json.get('foodCount')       
#             cursor = conn.cursor()
#             sql = 'exec USP_InsertBillInfo @idBill = ?, @idFood = ?, @count = ?'
#             data = (idBill, idFood, count)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
        
#     #Get Account By UserName
#     @app.route('/account/getaccountbyusername', methods = ['GET'])
#     def getAccountByUserName():
#         try:
#             username = flask.request.json.get('UserName')
#             cursor = conn.cursor()
#             sql = "exec USP_GetAccountByUserName @username = ?"
#             data = (username,)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
            
#     #Get List Bill By Date
#     @app.route('/bill/getbillbydate', methods = ['GET'])
#     def getBillByDate():
#         try:
#             checkIn = flask.request.json.get('checkIn')
#             checkOut = flask.request.json.get('checkOut')
#             cursor = conn.cursor()
#             sql = "exec USP_GetListBillByDate @checkIn = ?, @checkOut = ?"
#             data = (checkIn,checkOut)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #Get List Bill By Date And Page 
#     @app.route('/bill/getbillbydateandpage', methods = ['GET'])
#     def getBillByDateAndPage():
#         try:
#             checkIn = flask.request.json.get('checkIn')
#             checkOut = flask.request.json.get('checkOut')
#             page = flask.request.json.get('page')
#             cursor = conn.cursor()
#             sql = "exec USP_GetListBillByDateAndPage @checkIn = ?, @checkOut =?, @page =?"
#             data = (checkIn,checkOut,page)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetBillByDateForReport
#     @app.route('/bill/getbillbydateforreport', methods = ['GET'])
#     def getBillByDateForReport():
#         try:
#             checkIn = flask.request.json.get('checkIn')
#             checkOut = flask.request.json.get('checkOut')
#             cursor = conn.cursor()
#             sql = "exec USP_GetListBillByDateForReport @checkIn = ?, @checkOut = ?"
#             data = (checkIn,checkOut)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetNumBillByDate
#     @app.route('/bill/getnumbillbydate', methods = ['GET'])
#     def getNumBillByDate():
#         try:
#             checkIn = flask.request.json.get('checkIn')
#             checkOut = flask.request.json.get('checkOut')
#             cursor = conn.cursor()
#             sql = "exec USP_GetNumBillByDate @checkIn = ?, @checkOut = ?"
#             data = (checkIn,checkOut)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetBillByTableID
#     @app.route('/bill/getnumbillbytableid', methods = ['GET'])
#     def getNumBillByTableId():
#         try:
#             tableId = flask.request.json.get('idTable')
#             cursor = conn.cursor()
#             sql = "SELECT * FROM dbo.Bill WHERE idTable = ? AND status = 0"
#             data = (tableId,)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetMaxBillID
#     @app.route('/bill/getmaxbillid', methods = ['GET'])
#     def getMaxBillID():
#         try:
#             cursor = conn.cursor()
#             sql = "SELECT MAX(id) FROM dbo.Bill"
#             cursor.execute(sql)
#             max_id = cursor.fetchone()[0]
#             resp = flask.jsonify({"max_id": max_id})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #CheckOutBill
#     @app.route('/bill/checkout', methods = ['PUT'])
#     def checkoutBill():
#         try:
#             cursor = conn.cursor()
#             discount = flask.request.json.get('discount')
#             totalPrice = flask.request.json.get('totalPrice')
#             id = flask.request.json.get('id')         
#             sql = "Update dbo.Bill Set status = 1, DateCheckOut = GETDATE(), discount = ?, totalPrice = ? where id = ?"
#             data = (discount, totalPrice, id)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetTableList
#     @app.route('/table/gettablelist', methods = ['GET'])
#     def getTableList():
#         try:
#             cursor = conn.cursor()
#             sql = "exec USP_GetTableList"
#             cursor.execute(sql)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #Login
#     @app.route('/account/login', methods = ['GET'])
#     def loginAccount():
#         try:
#             userName = flask.request.json.get('UserName')
#             passWord = flask.request.json.get('PassWord')
#             cursor = conn.cursor()
#             sql = "exec USP_Login @username = ? , @password = ?"
#             data = (userName, passWord)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #SwitchTable
#     @app.route('/table/switchtable', methods=['PUT'])
#     def switchTable():
#         try:
#             idTable1 = flask.request.json.get('idTable1')
#             idTable2 = flask.request.json.get('idTable2')
#             cursor = conn.cursor()
#             sql = 'exec USP_SwitchTabel @idTable1 = ?, @idTable2 = ?'
#             data = (idTable1, idTable2)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #EditAccount
#     @app.route('/account/updateaccount', methods=['PUT'])
#     def UpdateAccount():
#         try:
#             username = flask.request.json.get('UserName')
#             displayname = flask.request.json.get('DisplayName')
#             password = flask.request.json.get('PassWord')
#             newpass = flask.request.json.get('NewPassword')        
#             cursor = conn.cursor()
#             sql = "exec USP_UpdateAccount @userName = ?, @displayName = ?, @password = ?, @newPassword = ?"
#             data = (username, displayname, password, newpass)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     # Get BillInfo
#     @app.route('/bill/getbillinfo', methods=['GET'])
#     def getBillInfo():
#         try:
#             idBill = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = "SELECT * FROM dbo.BillInfo WHERE idBill = ?"
#             data = (idBill,)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})

#     #GetListCategory
#     @app.route('/category/getlistcategory', methods=['GET'])
#     def getListCategory():
#         try:
#             cursor = conn.cursor()
#             sql = "SELECT * FROM dbo.FoodCategory"
#             cursor.execute(sql)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
        
#     #GetListMenuByTable
#     @app.route('/menu/getlistmenubytable', methods=['GET'])
#     def getListMenuByTable():
#         try:
#             idTable = flask.request.json.get('idTable')
#             cursor = conn.cursor()
#             sql = "SELECT f.name, bi.count, f.price, f.price* bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status=0 AND b.idTable = ?"
#             data = (idTable,)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetFoodByCategoryID
#     @app.route('/food/getlistfoodbycategory', methods=['GET'])
#     def getListFoodByCategory():
#         try:
#             idCategory = flask.request.json.get('idCategory')
#             cursor = conn.cursor()
#             sql = "select * from food where idCategory = ?"
#             data = (idCategory,)
#             cursor.execute(sql, data)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
#     #Insert Food
#     @app.route('/food/insert', methods=['POST'])
#     def insertFood():
#         try:
#             foodName = flask.request.json.get('name')
#             idCategory = flask.request.json.get('idCategory')
#             price = flask.request.json.get('price')
#             cursor = conn.cursor()
#             sql = 'Insert into food(name,idcategory,price) values (?,?,?)'
#             data = (foodName,idCategory,price)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #Edit Food
#     @app.route('/food/edit',methods = ['PUT'])
#     def EditFood():
#         try:
#             foodName = flask.request.json.get('name')
#             idCategory = flask.request.json.get('idCategory')
#             price = flask.request.json.get('price')
#             idFood = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = 'Update food set name = ?, idCategory = ?, price = ? where id = ?'
#             data = (foodName,idCategory,price,idFood)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
        
#     #Delete Food
#     @app.route('/food/delete',methods = ['DELETE'])
#     def DeleteFood():
#         try:
#             foodName = flask.request.json.get('name')
#             idFood = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = 'Delete from food Where id = ? AND name = ?'
#             data = (foodName,idFood)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
        
#     #NumBillInfoByFoodId
#     @app.route('/billinfo/getbillinfobyidfood', methods=['GET'])
#     def getNumBillInfoByIdFood():
#         try:
#             idFood = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = "select * from billinfo where idfood = ?"
#             cursor.execute(sql,idFood)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
        
#     #InsertCategory
#     @app.route('/category/insert', methods=['POST'])
#     def insertCategory():
#         try:
#             categoryName = flask.request.json.get('name')
#             cursor = conn.cursor()
#             sql = 'Insert into foodcategory(name) values(?)'
#             cursor.execute(sql, categoryName)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})  
    
#     #GetCategoryByName
#     @app.route('/category/getcategorybyname', methods=['GET'])
#     def getCategoryByName():
#         try:
#             categoryName = flask.request.json.get('name')
#             cursor = conn.cursor()
#             sql = "Select * from foodcategory Where name = ?"
#             cursor.execute(sql,categoryName)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #EditCategory
#     @app.route('/category/edit',methods = ['PUT'])
#     def EditCategory():
#         try:
#             categoryName = flask.request.json.get('name')
#             idCategory = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = 'Update foodcategory set Name = ? where id = ? '
#             data = (categoryName,idCategory)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
    
#     #Delete Category
#     @app.route('/category/delete',methods = ['DELETE'])
#     def DeleteCategory():
#         try:
#             categoryName = flask.request.json.get('name')
#             idCategory = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = 'Delete from foodcategory Where id = ? AND name = ?'
#             data = (categoryName,idCategory)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetTableByName
#     @app.route('/table/gettablebyname',methods=['GET'])
#     def GetTableByName():
#         try:
#             categoryName = flask.request.json.get('name')
#             cursor = conn.cursor()
#             sql = "Select * from tablefood Where name = ?"
#             cursor.execute(sql,categoryName)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #InsertTable
#     @app.route('/table/insert', methods=['POST'])
#     def insertTable():
#         try:
#             tableName = flask.request.json.get('name')
#             tableStatus = flask.request.json.get('status')
#             cursor = conn.cursor()
#             sql = 'insert into tablefood(name,status) values(?,?)'
#             data = (tableName,tableStatus)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #EditTable
#     @app.route('/table/edit',methods = ['PUT'])
#     def EditTable():
#         try:
#             tableName = flask.request.json.get('name')
#             idTable = flask.request.json.get('id')
#             statusTable = flask.request.json.get('status')
#             cursor = conn.cursor()
#             sql = 'Update TableFood set name = ? , status = ? where id = ?'
#             data = (tableName,statusTable,idTable)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
    
#     #DeleteTable
#     @app.route('/table/delete',methods = ['DELETE'])
#     def DeleteTable():
#         try:
#             tableName = flask.request.json.get('name')
#             idTable = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = 'Delete from tablefood Where id = ? AND name = ?'
#             data = (tableName,idTable)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetBillByIdTable
#     @app.route('/billinfo/getbillbyidtable', methods=['GET'])
#     def getBillByIdTable():
#         try:
#             idTable = flask.request.json.get('id')
#             cursor = conn.cursor()
#             sql = "select * from bill where idtable = ?"
#             cursor.execute(sql,idTable)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #InsertAccount
#     @app.route('/account/insert', methods=['POST'])
#     def insertAccount():
#         try:
#             userName = flask.request.json.get('UserName')
#             displayName = flask.request.json.get('DisplayName')
#             passWord = flask.request.json.get('PassWord')
#             typeAccount = flask.request.json.get('type')
#             cursor = conn.cursor()
#             sql = 'Insert into Account(username,displayname,password,type) values(?,?,?,?)'
#             data = (userName,displayName,passWord,typeAccount)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})
    
#     #EditAccount
#     @app.route('/account/edit',methods = ['PUT'])
#     def EditAccount():
#         try:
#             userName = flask.request.json.get('UserName')
#             displayName = flask.request.json.get('DisplayName')
#             passWord = flask.request.json.get('PassWord')
#             typeAccount = flask.request.json.get('type')
#             cursor = conn.cursor()
#             sql = 'Update Account set username = ?, displayname = ?,password =?, type = ? Where username = ? OR displayname = ? OR type = ?'
#             data = (userName,displayName,passWord,typeAccount,userName,displayName,typeAccount)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
    
#     #DeleteAccount
#     # @app.route('/account/delete',methods = ['DELETE'])
#     # def DeleteAccount():
#         try:
#             userName = flask.request.json.get('UserName')
#             displayName = flask.request.json.get('DisplayName')
#             cursor = conn.cursor()
#             sql = 'Delete from Account Where UserName = ? AND DisplayName = ?'
#             data = (userName,displayName)
#             cursor.execute(sql, data)
#             conn.commit()
#             resp = flask.jsonify({"mess": "Thành công"})
#             resp.status_code = 200
#             return resp
#         except:
#             return flask.jsonify({"mess": str(e)})
    
#     #GetAllListCategory
#     @app.route('/category/getalllistcategory', methods=['GET'])
#     def getAllListCategory():
#         try:
#             cursor = conn.cursor()
#             sql = "Select id as N'Mã loại', name as N'Tên loại' from foodcategory"
#             cursor.execute(sql)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})  
    
#     #GetAllListFood
#     @app.route('/food/getalllistfood', methods=['GET'])
#     def getAllListFood():
#         try:
#             cursor = conn.cursor()
#             sql = "Select id as N'Mã món ăn',name as N'Tên món ăn', idCategory as N'Mã loại', price as N'Đơn giá' from Food"
#             cursor.execute(sql)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})  
    
#     #GetAllListTable
#     @app.route('/table/getalllisttable', methods=['GET'])
#     def getAllListTable():
#         try:
#             cursor = conn.cursor()
#             sql = "Select id as N'Mã bàn', name as N'Tên bàn', status as N'Trạng thái' from TableFood"
#             cursor.execute(sql)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})  
    
#     #GetAllListAccount
#     @app.route('/account/getalllistaccount', methods=['GET'])
#     def getAllListAccount():
#         try:
#             cursor = conn.cursor()
#             sql = "select UserName as N'Tên tài khoản',Displayname as N'Tên người dùng',Type as N'Loại tài khoản' from Account"
#             cursor.execute(sql)
#             results = []
#             keys = [i[0] for i in cursor.description]
#             for row in cursor.fetchall():
#                 results.append(dict(zip(keys, row)))
#             resp = flask.jsonify(results)
#             resp.status_code = 200
#             return resp
#         except Exception as e:
#             return flask.jsonify({"mess": str(e)})  
    
#     if __name__ == '__main__':
#         app.run(port=3333)

# except Exception as e:
#     print("Thất bại")