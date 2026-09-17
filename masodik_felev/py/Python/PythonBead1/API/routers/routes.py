from schemas.schema import User, Basket, Item
from fastapi.responses import JSONResponse
from fastapi import HTTPException, APIRouter
from data.filehandler import add_user, add_basket, add_item_to_basket, save_json, edit_item, delete_item
from data.filereader import get_user_by_id, get_basket_by_user_id, get_all_users, get_total_price_of_basket, load_json
from typing import Dict, Any, List
'''

Útmutató a fájl használatához:

- Minden route esetén adjuk meg a response_modell értékét (típus)
- Ügyeljünk a típusok megadására
- A függvények visszatérési értéke JSONResponse() legyen
- Minden függvény tartalmazzon hibakezelést, hiba esetén dobjon egy HTTPException-t
- Az adatokat a data.json fájlba kell menteni.
- A HTTP válaszok minden esetben tartalmazzák a 
  megfelelő Státus Code-ot, pl 404 - Not found, vagy 200 - OK

'''

routers = APIRouter()
'''
@routers.post('/adduser')
def adduser(user):
    pass
'''
@routers.post('/adduser', response_model=User)
def adduser(user: User):
    try:
        add_user(user.model_dump()) 
        return JSONResponse(status_code=201, content=user.model_dump())
    except Exception as e:
        raise HTTPException(status_code=400, detail=str(e))

@routers.post('/addshoppingbag', response_model=Basket)
def addshoppingbag(userid: int) -> str:
    if (get_user_by_id(userid) == None):
        raise HTTPException(status_code=404, detail=("User not found"))
    data = load_json()
    baskets = data["Baskets"]
    try:
        max_id = max(basket["id"] for basket in baskets)+1
    except:
        max_id = 0
    basket = {
        "id": max_id,
        "user_id": userid,
        "items": []
        }
    try:
        add_basket(basket)
        return JSONResponse(status_code=201, content=basket)
    except Exception as e:
        raise HTTPException(status_code=400, detail=str(e))

@routers.post('/additem', response_model=Item)
def additem(userid: int, item: Item):
    basket = get_basket_by_user_id(userid)
    if (basket == None):
        raise HTTPException(status_code=404, detail=("User not found"))
    items = basket["items"]
    item = item.model_dump()
    for i in items:
        if (i["item_id"] == item["item_id"]):
            raise HTTPException(status_code=400, detail=("Item already exists in basket. Modify the quantity if you'd like to add more!"))
    try:
        add_item_to_basket(userid, item)
        return JSONResponse(status_code=201, content=item)
    except Exception as e:
        raise HTTPException(status_code=400, detail=str(e))



'''
@routers.put('/updateitem')
def updateitem(userid: int, itemid: int, edited: Item):
    #check if user exists 
    #check if basket exists
    #check if item exists
    #form item with modeldump
    user_data = get_user_by_id(userid)
    if user_data is None:
        raise HTTPException(status_code=404, detail="User not found") 
    basket = get_basket_by_user_id(userid)
    if basket is None:
        raise HTTPException(status_code=404, detail="Basket not found")
    
    for i in basket["items"]:
        if i["id"] == itemid:
            try:
                edit_item(userid, edited.model_dump())
                return JSONResponse(status_code=200, content=basket)
            except:
                raise HTTPException(status_code=400, detail="Something went wrong")
'''
@routers.put('/updateitem')
def updateitem(userid: int, itemid: int, edited: Item):
    #check if user exists 
    #check if basket exists
    #check if item exists
    #form item with modeldump
    user_data = get_user_by_id(userid)
    if user_data is None:
        raise HTTPException(status_code=404, detail="User not found") 
    basket = get_basket_by_user_id(userid)
    if basket is None:
        raise HTTPException(status_code=404, detail="Basket not found")
    for i in basket["items"]:
        if i["item_id"] == itemid:
            try:
                edit_item(userid, edited.model_dump())
                updated_basket = get_basket_by_user_id(userid)
                return JSONResponse(status_code=200, content=updated_basket)
            except Exception as e:
                raise HTTPException(status_code=400, detail=str(e))     
    raise HTTPException(status_code=404, detail="Item not found in basket")
'''
    try:
        edit_item(userid, edited.model_dump())
        updated_basket = get_basket_by_user_id(userid)
        return JSONResponse(status_code=200, content=updated_basket)
    except Exception as e:
        raise HTTPException(status_code=400, detail=str(e))
'''

@routers.delete('/deleteitem')
def deleteitem(userid: int, itemid: int):
    user_data = get_user_by_id(userid)
    if user_data is None:
        raise HTTPException(status_code=404, detail="User not found") 
    basket = get_basket_by_user_id(userid)
    if basket is None:
        raise HTTPException(status_code=404, detail="Basket not found")
    for i in basket["items"]:
        if i["item_id"] == itemid:
            try:
                delete_item(userid, itemid)
                updated_basket = get_basket_by_user_id(userid)
                return JSONResponse(status_code=200, content=updated_basket)
            except Exception as e:
                raise HTTPException(status_code=400, detail=str(e))     
    raise HTTPException(status_code=404, detail="Item not found in basket")

@routers.get('/user', response_model=User)
def user(userid: int):
    user_data = get_user_by_id(userid)
    if user_data is None:
        raise HTTPException(status_code=404, detail="User not found")
    return JSONResponse(status_code=200, content=user_data)

@routers.get('/users', response_model=List[User])
def users():
    try:
        sto = get_all_users()
        return JSONResponse(status_code=200, content=sto)
    except:
        raise HTTPException(status_code=400, detail="Something went wrong")

@routers.get('/shoppingbag', response_model=Basket)
def shoppingbag(userid: int):
    if (get_user_by_id(userid) == None):
        raise HTTPException(status_code=404, detail="User not found")
    try:
        basket = get_basket_by_user_id(userid)
        if (basket == None):
            raise HTTPException(status_code=404, detail="Basket not found")
        else:
            return JSONResponse(status_code=200, content=basket)
    except:
        raise HTTPException(status_code=400, detail="Something went wrong")

@routers.get('/getusertotal', response_model=float)
def getusertotal(userid: int) -> float:
    user_data = get_user_by_id(userid)
    if user_data is None:
        raise HTTPException(status_code=404, detail="User not found")
    basket = get_basket_by_user_id(userid)
    if basket is None:
        raise HTTPException(status_code=404, detail="Basket not found")
    try:
        num=get_total_price_of_basket(userid)
        return JSONResponse(status_code=200, content=num)
    except:
        raise HTTPException(status_code=400, detail="I don't even know")