import json
import os
from typing import Dict, Any
from data.filereader import get_user_by_id, get_basket_by_user_id, get_all_users, get_total_price_of_basket, load_json
from schemas.schema import User, Basket, Item
from fastapi.responses import JSONResponse
from fastapi import HTTPException, APIRouter

'''
Útmutató a fájl függvényeinek a használatához

Új felhasználó hozzáadása:

new_user = {
    "id": 4,  # Egyedi felhasználó azonosító
    "name": "Szilvás Szabolcs",
    "email": "szabolcs@plumworld.com"
}

Felhasználó hozzáadása a JSON fájlhoz:

add_user(new_user)

Hozzáadunk egy új kosarat egy meglévő felhasználóhoz:

new_basket = {
    "id": 104,  # Egyedi kosár azonosító
    "user_id": 2,  # Az a felhasználó, akihez a kosár tartozik
    "items": []  # Kezdetben üres kosár
}

add_basket(new_basket)

Új termék hozzáadása egy felhasználó kosarához:

user_id = 2
new_item = {
    "item_id": 205,
    "name": "Szilva",
    "brand": "Stanley",
    "price": 7.99,
    "quantity": 3
}

Termék hozzáadása a kosárhoz:

add_item_to_basket(user_id, new_item)

Hogyan használd a fájlt?

Importáld a függvényeket a filehandler.py modulból:

from filehandler import (
    add_user,
    add_basket,
    add_item_to_basket,
)

 - Hiba esetén ValuErrort kell dobni, lehetőség szerint ezt a 
   kliens oldalon is jelezni kell.

'''

JSON_FILE_PATH = os.path.join(os.path.dirname(__file__), "data.json")

def load_json() -> Dict[str, Any]:
    if not os.path.exists(JSON_FILE_PATH):
        return {"Users": [], "Baskets": []}
    with open(JSON_FILE_PATH, "r", encoding="utf-8") as f:
        return json.load(f)

def save_json(data: Dict[str, Any]) -> None:
    with open(JSON_FILE_PATH, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=2, ensure_ascii=False)

def add_user(user: Dict[str, Any]) -> None:
    data = load_json() 
    for existing_user in data["Users"]:
        if existing_user["id"] == user["id"]:
            raise ValueError("Id already taken!")
    data["Users"].append(user)
    save_json(data)

def add_basket(basket: Dict[str, Any]) -> None:
    data = load_json()
    for i in data["Baskets"]:
        if i["user_id"] == basket["user_id"]:
            raise ValueError("Already assigned basket!")
    data["Baskets"].append(basket)
    save_json(data)
'''
def add_item_to_basket(user_id: int, item: Dict[str, Any]) -> None:
    data = load_json()
    basket = get_basket_by_user_id(user_id)
    basket["items"].append(item)
    save_json(data)
'''
def add_item_to_basket(user_id: int, item: Dict[str, Any]) -> None:
    data = load_json()
    for basket in data["Baskets"]:
        if basket["user_id"] == user_id:
            basket["items"].append(item)
            save_json(data)
            return
    raise ValueError("Basket not found")
    
def edit_item(user_id: int, edited: Dict[str,Any]) -> None:
    data = load_json()
    for basket in data["Baskets"]:
        if basket["user_id"] == user_id:
            for thing in basket["items"]:
                if edited["item_id"] == thing["item_id"]:
                    thing.update(edited)
                    save_json(data)
                    return
    raise ValueError("Basket not found")
                

def delete_item(user_id: int, itemid: int) -> None:
    data = load_json()
    for basket in data["Baskets"]:
        if basket["user_id"] == user_id:
            basket["items"] = [i for i in basket["items"] if i["item_id"] != itemid]
            save_json(data)
            return
            '''count = 0
            for thing in basket["items"]:
                if thing["item_id"] == itemid:
                    basket["items"].pop(count)
                    save_json(data)
                    return 
            count += 1'''
    raise ValueError("Basket not found")