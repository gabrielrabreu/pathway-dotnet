–
jC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\CommandHandlers\CommandHandler.cs
	namespace		 	
Core		
 
.		 
Domain		 
.		 
CommandHandlers		 %
{

 
public 

abstract 
class 
CommandHandler (
{ 
private 
readonly 
IMediatorHandler )
_mediatorHandler* :
;: ;
private 
readonly %
DomainNotificationHandler 2
_notifications3 A
;A B
	protected 
CommandHandler  
(  !
IMediatorHandler! 1
mediatorHandler2 A
,A B 
INotificationHandler! 5
<5 6
DomainNotification6 H
>H I
notificationsJ W
)W X
{ 	
_mediatorHandler 
= 
mediatorHandler .
;. /
_notifications 
= 
( %
DomainNotificationHandler 7
)7 8
notifications8 E
;E F
} 	
	protected 
async 
Task 
< 
bool !
>! "
Commit# )
() *
IUnitOfWork* 5
uow6 9
)9 :
{ 	
if 
( 
_notifications 
. 
HasNotifications /
(/ 0
)0 1
)1 2
{ 
await 
_mediatorHandler &
.& '%
PublishDomainNotification' @
(@ A
newA D
DomainNotificationE W
(W X
$strX `
,` a
DomainMessages "
." #
CommitFailed# /
./ 0
Message0 7
)7 8
)8 9
;9 :
return 
false 
; 
} 
if   
(   
await   
uow   
.   
Commit    
(    !
)  ! "
)  " #
return  $ *
true  + /
;  / 0
await"" 
_mediatorHandler"" "
.""" #%
PublishDomainNotification""# <
(""< =
new""= @
DomainNotification""A S
(""S T
$str""T \
,""\ ]
DomainMessages## 
.## 
CommitFailed## +
.##+ ,
Message##, 3
)##3 4
)##4 5
;##5 6
return$$ 
false$$ 
;$$ 
}%% 	
	protected'' 
async'' 
Task'' #
PublishValidationErrors'' 4
(''4 5
Command''5 <
command''= D
)''D E
{(( 	
foreach)) 
()) 
var)) 
error)) 
in)) !
command))" )
.))) *
ValidationResult))* :
.)): ;
Errors)); A
)))A B
{** 
await++ 
_mediatorHandler++ &
.++& '%
PublishDomainNotification++' @
(++@ A
new++A D
DomainNotification++E W
(++W X
command++X _
.++_ `
MessageType++` k
,++k l
error,, 
.,, 
ErrorMessage,, &
),,& '
),,' (
;,,( )
}-- 
}.. 	
}// 
}00 ì
\C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Commands\Command.cs
	namespace 	
Core
 
. 
Domain 
. 
Commands 
{ 
public 

abstract 
class 
Command !
:" #
Message$ +
,+ ,
IRequest- 5
<5 6
Unit6 :
>: ;
{		 
public

 
virtual

 
ValidationResult

 '
ValidationResult

( 8
{

9 :
get

; >
;

> ?
	protected

@ I
set

J M
;

M N
}

O P
	protected 
Command 
( 
Guid 
aggregateId *
)* +
:, -
base. 2
(2 3
aggregateId3 >
)> ?
{@ A
}B C
public 
abstract 
bool 
IsValid $
($ %
)% &
;& '
} 
} Ô
`C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Common\DomainMessage.cs
	namespace 	
Core
 
. 
Domain 
. 
Common 
{ 
public 

class 
DomainMessage 
{ 
public 
string 
Message 
{ 
get  #
;# $
}% &
public 
DomainMessage 
( 
string #
message$ +
)+ ,
{ 	
Message		 
=		 
message		 
;		 
}

 	
public 
DomainMessage 
Format #
(# $
params$ *
object+ 1
[1 2
]2 3
args4 8
)8 9
{ 	
return 
new 
DomainMessage $
($ %
string% +
.+ ,
Format, 2
(2 3
Message3 :
,: ;
args< @
)@ A
)A B
;B C
} 	
} 
} ‘
aC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Common\DomainMessages.cs
	namespace 	
Core
 
. 
Domain 
. 
Common 
{ 
public 

static 
class 
DomainMessages &
{ 
public 
static 
DomainMessage #
CommitFailed$ 0
=>1 3
new4 7
(7 8
$str8 Y
)Y Z
;Z [
public 
static 
DomainMessage #
RequiredField$ 1
=>2 4
new5 8
(8 9
$str9 X
)X Y
;Y Z
public 
static 
DomainMessage #
AlreadyInUse$ 0
=>1 3
new4 7
(7 8
$str8 ]
)] ^
;^ _
public 
static 
DomainMessage #
InvalidFormat$ 1
=>2 4
new5 8
(8 9
$str9 W
)W X
;X Y
public		 
static		 
DomainMessage		 #!
MustBeGreatherOrEqual		$ 9
=>		: <
new		= @
(		@ A
$str		A z
)		z {
;		{ |
public

 
static

 
DomainMessage

 #
NotFound

$ ,
=>

- /
new

0 3
(

3 4
$str

4 U
)

U V
;

V W
} 
} ≠
aC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Common\EnumExtensions.cs
	namespace 	
Core
 
. 
Domain 
. 
Common 
{ 
public 

static 
class 
EnumExtensions &
{ 
public		 
static		 
string		 
GetDescription		 +
(		+ ,
this		, 0
Enum		1 5
value		6 ;
)		; <
{

 	
Type 
type 
= 
value 
. 
GetType %
(% &
)& '
;' (
string 
name 
= 
Enum 
. 
GetName &
(& '
type' +
,+ ,
value- 2
)2 3
;3 4
if 
( 
name 
!= 
null 
) 
{ 
	FieldInfo 
field 
=  !
type" &
.& '
GetField' /
(/ 0
name0 4
)4 5
;5 6
if 
( 
field 
!= 
null !
)! "
{  
DescriptionAttribute (
attr) -
=. /
	Attribute $
.$ %
GetCustomAttribute% 7
(7 8
field8 =
,= >
typeof #
(# $ 
DescriptionAttribute$ 8
)8 9
)9 :
as; = 
DescriptionAttribute> R
;R S
if 
( 
attr 
!= 
null  $
)$ %
{ 
return 
attr #
.# $
Description$ /
;/ 0
} 
} 
} 
return 
null 
; 
} 	
} 
} ß
cC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Common\StringExtensions.cs
	namespace 	
Core
 
. 
Domain 
. 
Common 
{ 
public 

static 
class 
StringExtensions (
{ 
public 
static 
IEnumerable !
<! "
string" (
>( )
	ReadLines* 3
(3 4
this4 8
string9 ?
content@ G
)G H
{		 	
var

 
lines

 
=

 
new

 
List

  
<

  !
string

! '
>

' (
(

( )
)

) *
;

* +
using 
( 
var 
reader 
= 
new  #
StringReader$ 0
(0 1
content1 8
)8 9
)9 :
{ 
string 
line 
; 
while 
( 
( 
line 
= 
reader %
.% &
ReadLine& .
(. /
)/ 0
)0 1
!=2 4
null5 9
)9 :
{ 
if 
( 
! 
string 
.  
IsNullOrEmpty  -
(- .
line. 2
)2 3
)3 4
{ 
lines 
. 
Add !
(! "
line" &
)& '
;' (
} 
} 
} 
return 
lines 
; 
} 	
} 
} ˛
[C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Entities\Entity.cs
	namespace 	
Core
 
. 
Domain 
. 
Entities 
{ 
public 

abstract 
class 
Entity  
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
int 
Code 
{ 
get 
; 
set "
;" #
}$ %
}		 
}

 Ü
XC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Events\Event.cs
	namespace 	
Core
 
. 
Domain 
. 
Events 
{ 
public 

abstract 
class 
Event 
:  !
Message" )
,) *
INotification+ 8
{ 
	protected 
Event 
( 
Guid 
aggregateId (
)( )
:* +
base, 0
(0 1
aggregateId1 <
)< =
{> ?
}@ A
}		 
}

 Õ

ZC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Events\Message.cs
	namespace 	
Core
 
. 
Domain 
. 
Events 
{ 
public 

abstract 
class 
Message !
{ 
public 
string 
MessageType !
{" #
get$ '
;' (
	protected) 2
set3 6
;6 7
}8 9
public 
Guid 
AggregateId 
{  !
get" %
;% &
	protected' 0
set1 4
;4 5
}6 7
public		 
DateTime		 
	Timestamp		 !
{		" #
get		$ '
;		' (
private		) 0
set		1 4
;		4 5
}		6 7
	protected 
Message 
( 
Guid 
aggregateId *
)* +
{ 	
AggregateId 
= 
aggregateId %
;% &
MessageType 
= 
GetType !
(! "
)" #
.# $
Name$ (
;( )
	Timestamp 
= 
DateTime  
.  !
UtcNow! '
;' (
} 	
} 
} ê
bC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Interfaces\IRepository.cs
	namespace 	
Core
 
. 
Domain 
. 

Interfaces  
{		 
public

 

	interface

 
IRepository

  
<

  !
TEntity

! (
>

( )
where

* /
TEntity

0 7
:

8 9
Entity

: @
{ 
IUnitOfWork 

UnitOfWork 
{  
get! $
;$ %
}& '
Task 
< 
IEnumerable 
< 
TEntity  
>  !
>! "
Search# )
() *

Expression* 4
<4 5
Func5 9
<9 :
TEntity: A
,A B
boolC G
>G H
>H I
	predicateJ S
)S T
;T U
Task 
< 
IEnumerable 
< 
TEntity  
>  !
>! "
GetAll# )
() *
)* +
;+ ,
Task 
< 
TEntity 
> 
GetById 
( 
Guid "
id# %
)% &
;& '

IQueryable 
< 
TEntity 
> 
Query !
(! "
)" #
;# $
void 
Add 
( 
TEntity 
entity 
)  
;  !
void 
Update 
( 
TEntity 
entity "
)" #
;# $
void 
Remove 
( 
TEntity 
entity "
)" #
;# $
} 
} ‘
bC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Interfaces\IUnitOfWork.cs
	namespace 	
Core
 
. 
Domain 
. 

Interfaces  
{ 
public 

	interface 
IUnitOfWork  
{ 
Task 
< 
bool 
> 
Commit 
( 
) 
; 
} 
}		 
eC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Mediator\IMediatorHandler.cs
	namespace 	
Core
 
. 
Domain 
. 
Mediator 
{ 
public		 

	interface		 
IMediatorHandler		 %
{

 
Task 
PublishEvent 
< 
T 
> 
( 
T 
@event %
)% &
where' ,
T- .
:/ 0
Event1 6
;6 7
Task 
< 
Unit 
> 
SendCommand 
< 
T  
>  !
(! "
T" #
command$ +
)+ ,
where- 2
T3 4
:5 6
Command7 >
;> ?
Task %
PublishDomainNotification &
<& '
T' (
>( )
() *
T* +
notification, 8
)8 9
where: ?
T@ A
:B C
DomainNotificationD V
;V W
} 
} À
dC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Mediator\MediatorHandler.cs
	namespace 	
Core
 
. 
Domain 
. 
Mediator 
{ 
public		 

class		 
MediatorHandler		  
:		! "
IMediatorHandler		# 3
{

 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
MediatorHandler 
( 
	IMediator (
mediator) 1
)1 2
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< 
Unit 
> 
SendCommand  +
<+ ,
T, -
>- .
(. /
T/ 0
command1 8
)8 9
where: ?
T@ A
:B C
CommandD K
{ 	
return 
await 
	_mediator "
." #
Send# '
(' (
command( /
)/ 0
;0 1
} 	
public 
async 
Task 
PublishEvent &
<& '
T' (
>( )
() *
T* +
@event, 2
)2 3
where4 9
T: ;
:< =
Event> C
{ 	
await 
	_mediator 
. 
Publish #
(# $
@event$ *
)* +
;+ ,
} 	
public 
async 
Task %
PublishDomainNotification 3
<3 4
T4 5
>5 6
(6 7
T7 8
notification9 E
)E F
whereG L
TM N
:O P
DomainNotificationQ c
{ 	
await 
	_mediator 
. 
Publish #
(# $
notification$ 0
)0 1
;1 2
} 	
}   
}!! Å	
lC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Notifications\DomainNotification.cs
	namespace 	
Core
 
. 
Domain 
. 
Notifications #
{ 
public 

class 
DomainNotification #
:$ %
Message& -
,- .
INotification/ <
{ 
public		 
string		 
Key		 
{		 
get		 
;		  
}		! "
public

 
string

 
Value

 
{

 
get

 !
;

! "
}

# $
public 
DomainNotification !
(! "
string" (
key) ,
,, -
string. 4
value5 :
): ;
:< =
base> B
(B C
GuidC G
.G H
NewGuidH O
(O P
)P Q
)Q R
{ 	
Key 
= 
key 
; 
Value 
= 
value 
; 
} 	
} 
} å
sC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Notifications\DomainNotificationHandler.cs
	namespace 	
Core
 
. 
Domain 
. 
Notifications #
{ 
public 

class %
DomainNotificationHandler *
:+ , 
INotificationHandler- A
<A B
DomainNotificationB T
>T U
{		 
private

 
List

 
<

 
DomainNotification

 '
>

' (
_notifications

) 7
;

7 8
public %
DomainNotificationHandler (
(( )
)) *
{ 	
_notifications 
= 
new  
List! %
<% &
DomainNotification& 8
>8 9
(9 :
): ;
;; <
} 	
public 
Task 
Handle 
( 
DomainNotification -
message. 5
,5 6
CancellationToken7 H
cancellationTokenI Z
)Z [
{ 	
_notifications 
. 
Add 
( 
message &
)& '
;' (
return 
Task 
. 
CompletedTask %
;% &
} 	
public 
virtual 
List 
< 
DomainNotification .
>. /
GetNotifications0 @
(@ A
)A B
{ 	
return 
_notifications !
;! "
} 	
public 
virtual 
bool 
HasNotifications ,
(, -
)- .
{ 	
return 
GetNotifications #
(# $
)$ %
.% &
Count& +
>, -
$num. /
;/ 0
} 	
public!! 
virtual!! 
void!! 
ClearNotifications!! .
(!!. /
)!!/ 0
{"" 	
_notifications## 
=## 
new##  
List##! %
<##% &
DomainNotification##& 8
>##8 9
(##9 :
)##: ;
;##; <
}$$ 	
}%% 
}&& ¨
gC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Domain\Validators\CommandValidator.cs
	namespace 	
Core
 
. 
Domain 
. 

Validators  
{ 
public 

abstract 
class 
CommandValidator *
<* +
T+ ,
>, -
:. /
AbstractValidator0 A
<A B
TB C
>C D
whereE J
TK L
:M N
CommandO V
{ 
	protected 
CommandValidator "
(" #
)# $
{% &
}' (
}		 
}

 