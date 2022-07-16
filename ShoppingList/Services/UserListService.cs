﻿namespace ShoppingList.Services;
public class UserListService
{
    DatabaseHandler _db; 
    
    public UserListService()
    {
        _db = new DatabaseHandler();
    }

    public UserListService(DatabaseHandler db)
    {
        _db = db;
    }

    public List<UserList> GetUserLists()
    {
        var returnLists = _db.GetAllQuery<UserList>(); 
        return returnLists; 
    }

    public List<UserList> GetUserListByName(string name)
    {

        var returnLists = _db.GetQueryByName<UserList>(name);
        return returnLists; 
    }

    public UserList GetUserListById(UserList ul)
    {
        var returnLists = _db.GetQueryById<UserList>(ul.Id);
        return returnLists; 
    }
    public List<Item> GetUserListItems(UserList ul)
    {
        var returnLists = _db.GetQueryById<UserList>(ul.Id);
        return returnLists.Items; 
    }

    public UserList CreateUserList(UserList newlist)
    {
        return _db.Insert(newlist); 

    }

    public void DeleteUserList(UserList newlist)
    {
        _db.Delete(newlist);
    }
}


