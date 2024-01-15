°
kC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.API\Common\UnprocessableEntityResponse.cs
	namespace 	
Core
 
. 
API 
. 
Common 
{ 
public 

class '
UnprocessableEntityResponse ,
{ 
public 
IEnumerable 
< 
string !
>! "
Errors# )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
}		 ñ
cC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.API\Controllers\BaseController.cs
	namespace 	
Core
 
. 
API 
. 
Controllers 
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str 
) 
] 
public 

abstract 
class 
BaseController (
:) *
ControllerBase+ 9
{ 
private 
readonly %
DomainNotificationHandler 2
_notifications3 A
;A B
	protected 
BaseController  
(  ! 
INotificationHandler! 5
<5 6
DomainNotification6 H
>H I
notificationsJ W
)W X
{ 	
_notifications 
= 
( %
DomainNotificationHandler 7
)7 8
notifications8 E
;E F
} 	
private 
IEnumerable 
< 
string "
>" #
GetValidationErrors$ 7
(7 8
)8 9
{ 	
return 
_notifications !
.! "
GetNotifications" 2
(2 3
)3 4
.4 5
Select5 ;
(; <
c< =
=>> @
cA B
.B C
ValueC H
)H I
;I J
} 	
private 
bool 
ValidOperation #
(# $
)$ %
{ 	
return 
! 
_notifications "
." #
HasNotifications# 3
(3 4
)4 5
;5 6
} 	
	protected 
new 
IActionResult #
Response$ ,
(, -
)- .
{   	
if!! 
(!! 
ValidOperation!! 
(!! 
)!!  
)!!  !
{"" 
return## 
Ok## 
(## 
)## 
;## 
}$$ 
else%% 
{&& 
return'' 
UnprocessableEntity'' *
(''* +
new''+ .'
UnprocessableEntityResponse''/ J
(''J K
)''K L
{(( 
Errors)) 
=)) 
GetValidationErrors)) 0
())0 1
)))1 2
}** 
)** 
;** 
}++ 
},, 	
}-- 
}.. 