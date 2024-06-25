select users.Id,
users.Fname,
users.Lname,
users.Email,
users.IsActive, 
roles.Name as Role
from AspNetUsers users
left outer join AspNetUserRoles userroles
on users.Id = userroles.UserId
left outer join AspNetRoles roles
on userroles.RoleId = roles.Id;