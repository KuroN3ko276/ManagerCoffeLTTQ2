import pyodbc
import flask

con_str = (
    "Driver={SQL Server};"
    "Server=KURON3KO\HAIDANG;"
    "Database=QLCoffeLTTQ;"
    "Trusted_Connection=yes;"
)

try:
    conn = pyodbc.connect(con_str)
    app = flask.Flask(__name__)

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
            sql = "exec USP_GetNumBillByDate @checkIn = ?, @checkOut = ?"
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
