# API for Meetings

## Launching Web Service:

Clone git repository:
```
git clone https://github.com/Shilis/Meetings-API.git
```

Navigate to the directory on command line:

```
cd Meetings-API
```

Create docker image:

```
docker build -f Meetings-API/Dockerfile -t meetings-api .
```

Run container: 
```
docker run -it --rm -p 80:80 meetings-api
```

Open localhost/swagger in a browser to manipulate data


## Instructions:

GET
```
List of all meetings:
/meetings

Meeting with particular id: 
/meetings/<id>

List of all users:
/users

User with particular id: 
/users/<id>
```

PUT 
```
Update particular meeting: 
/meetings/<id>

Update particular user: 
/users/<id>

Add user to meeting:
/meetings/<id>/users/<userId>
```

DELETE
```
Remove particular meeting: 
/meetings/<id>

Remove particular user:
/users/<id>

Remove user from meeting:
/meetings/<id>/users/<userId>
```

POST
```
Add new contact: 
/meetings

Add new user:
/users
```
