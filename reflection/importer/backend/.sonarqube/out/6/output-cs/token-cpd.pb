ç
wC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Application\DataTransferObjects\DataTransferObject.cs
	namespace 	
Core
 
. 
Application 
. 
DataTransferObjects .
{ 
public 

abstract 
class 
DataTransferObject ,
{- .
}/ 0
} ≥
gC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Application\Interfaces\IAppService.cs
	namespace 	
Core
 
. 
Application 
. 

Interfaces %
{ 
public 

	interface 
IAppService  
<  !
TDTO! %
,% &
TAddDTO' .
>. /
where		 
TDTO		 
:		 
DataTransferObject		 '
where

 
TAddDTO

 
:

 
DataTransferObject

 *
{ 
Task 
< 
IEnumerable 
< 
TDTO 
> 
> 
GetAll  &
(& '
)' (
;( )
Task 
< 
TDTO 
> 
GetById 
( 
Guid 
id  "
)" #
;# $
Task 
Add 
( 
TAddDTO 
addDTO 
)  
;  !
} 
} Œ
dC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Core.Application\Services\AppService.cs
	namespace

 	
Core


 
.

 
Application

 
.

 
Services

 #
{ 
public 

abstract 
class 

AppService $
<$ %
TDTO% )
,) *
TAddDTO+ 2
,2 3
TEntity4 ;
>; <
:= >
IAppService? J
<J K
TDTOK O
,O P
TAddDTOQ X
>X Y
where 
TDTO 
: 
DataTransferObject '
where 
TAddDTO 
: 
DataTransferObject *
where 
TEntity 
: 
Entity 
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IRepository $
<$ %
TEntity% ,
>, -
_repository. 9
;9 :
	protected 

AppService 
( 
IMapper $
mapper% +
,+ ,
IRepository (
<( )
TEntity) 0
>0 1

repository2 <
)< =
{ 	
_mapper 
= 
mapper 
; 
_repository 
= 

repository $
;$ %
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
TDTO& *
>* +
>+ ,
GetAll- 3
(3 4
)4 5
{ 	
return 
_mapper 
. 
Map 
< 
IEnumerable *
<* +
TDTO+ /
>/ 0
>0 1
(1 2
await2 7
_repository8 C
.C D
GetAllD J
(J K
)K L
)L M
;M N
} 	
public   
async   
Task   
<   
TDTO   
>   
GetById    '
(  ' (
Guid  ( ,
id  - /
)  / 0
{!! 	
return"" 
_mapper"" 
."" 
Map"" 
<"" 
TDTO"" #
>""# $
(""$ %
await""% *
_repository""+ 6
.""6 7
GetById""7 >
(""> ?
id""? A
)""A B
)""B C
;""C D
}## 	
public%% 
abstract%% 
Task%% 
Add%%  
(%%  !
TAddDTO%%! (
addDTO%%) /
)%%/ 0
;%%0 1
}&& 
}'' 