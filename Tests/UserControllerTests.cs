using NUnit.Framework;
using Moq;
using System.Web.Mvc;
using CRUD_application_2.Models;
using CRUD_application_2.Controllers;
using System.Collections.Generic;
using System.Linq;


[TestFixture]
public class UserControllerTests
{
    private UserController _controller;
    private List<User> _userList;

    [SetUp]
    public void Setup()
    {
        _userList = new List<User>
        {
            new User { Id = 1, Name = "Test User 1", Email = "test1@example.com" },
            new User { Id = 2, Name = "Test User 2", Email = "test2@example.com" },
            new User { Id = 3, Name = "Test User 3", Email = "test3@example.com" }
        };

        UserController.userlist = _userList;
        _controller = new UserController();
    }

    [Test]
    public void Index_ReturnsViewWithUserList()
    {
        var result = _controller.Index() as ViewResult;
        var model = result.Model as List<User>;

        Assert.That(model.Count, Is.EqualTo(_userList.Count));
    }

    [Test]
    public void Details_ReturnsUserDetails()
    {
        var result = _controller.Details(1) as ViewResult;
        var model = result.Model as User;

        Assert.That(model.Name, Is.EqualTo("Test User 1"));
    }

    [Test]
    public void Create_AddsNewUser()
    {
        var newUser = new User { Id = 4, Name = "Test User 4", Email = "test4@example.com" };
        _controller.Create(newUser);

        Assert.That(UserController.userlist.Count, Is.EqualTo(4));
        Assert.That(UserController.userlist.Last(), Is.EqualTo(newUser));
    }

    [Test]
    public void Edit_UpdatesExistingUser()
    {
        var updatedUser = new User { Id = 1, Name = "Updated User", Email = "updated@example.com" };
        _controller.Edit(1, updatedUser);

        var user = UserController.userlist.First(u => u.Id == 1);

        Assert.That(user.Name, Is.EqualTo("Updated User"));
        Assert.That(user.Email, Is.EqualTo("updated@example.com"));
    }

    [Test]
    public void Delete_RemovesUser()
    {
        _controller.Delete(1, new FormCollection());

        Assert.That(UserController.userlist.Count, Is.EqualTo(2));
        Assert.That(UserController.userlist.Any(u => u.Id == 1), Is.False);
    }
}
