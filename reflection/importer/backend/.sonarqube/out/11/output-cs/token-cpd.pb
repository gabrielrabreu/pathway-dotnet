ê<
{C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\AutoMapper\DtoToCommandMappingProfile.cs
	namespace 	
	Something
 
. 
Application 
.  

AutoMapper  *
{ 
public 

class &
DtoToCommandMappingProfile +
:, -
Profile. 5
{ 
public &
DtoToCommandMappingProfile )
() *
)* +
{ 	
CreateXptoMap 
( 
) 
; !
CreateImportLayoutMap !
(! "
)" #
;# $
CreateImportMap 
( 
) 
; 
} 	
private 
void 
CreateXptoMap "
(" #
)# $
{ 	
	CreateMap 
< 

AddXptoDto  
,  !
AddXptoCommand" 0
>0 1
(1 2
)2 3
. 
	ForMember 
( 
d 
=> 
d  !
.! "
Entity" (
,( )
o* +
=>, .
o/ 0
.0 1
MapFrom1 8
(8 9
s9 :
=>; =
new> A
XptoB F
(F G
)G H
{ 
Name 
= 
s 
. 
Name !
,! "
Date 
= 
s 
. 
Date !
,! "
Version 
= 
s 
.  
Version  '
,' (
Value   
=   
s   
.   
Value   #
}!! 
)!! 
)!! 
;!! 
}"" 	
private$$ 
void$$ !
CreateImportLayoutMap$$ *
($$* +
)$$+ ,
{%% 	
	CreateMap&& 
<&& 
AddImportLayoutDto&& (
,&&( )"
AddImportLayoutCommand&&* @
>&&@ A
(&&A B
)&&B C
.'' 
	ForMember'' 
('' 
d'' 
=>'' 
d''  !
.''! "
Entity''" (
,''( )
o''* +
=>'', .
o''/ 0
.''0 1
MapFrom''1 8
(''8 9
s''9 :
=>''; =
new''> A
ImportLayout''B N
(''N O
)''O P
)''P Q
)''Q R
.(( 
ForPath(( 
((( 
d(( 
=>(( 
d(( 
.((  
Entity((  &
.((& '
Name((' +
,((+ ,
o((- .
=>((/ 1
o((2 3
.((3 4
MapFrom((4 ;
(((; <
s((< =
=>((> @
s((A B
.((B C
Name((C G
)((G H
)((H I
.)) 
ForPath)) 
()) 
d)) 
=>)) 
d)) 
.))  
Entity))  &
.))& '
	Separator))' 0
,))0 1
o))2 3
=>))4 6
o))7 8
.))8 9
MapFrom))9 @
())@ A
s))A B
=>))C E
s))F G
.))G H
	Separator))H Q
)))Q R
)))R S
.** 
ForPath** 
(** 
d** 
=>** 
d** 
.**  
Entity**  &
.**& '
Service**' .
,**. /
o**0 1
=>**2 4
o**5 6
.**6 7
MapFrom**7 >
(**> ?
s**? @
=>**A C
s**D E
.**E F
Service**F M
)**M N
)**N O
.++ 
ForPath++ 
(++ 
d++ 
=>++ 
d++ 
.++  
Entity++  &
.++& '
Columns++' .
,++. /
o++0 1
=>++2 4
o++5 6
.++6 7
MapFrom++7 >
(++> ?
s++? @
=>++A C
s++D E
.++E F
Columns++F M
.++M N
Select++N T
(++T U
s2++U W
=>++X Z
new++[ ^
ImportLayoutColumn++_ q
{,, 
Name-- 
=-- 
s2-- 
.-- 
Name-- "
,--" #
Position.. 
=.. 
s2.. !
...! "
Position.." *
,..* +
Format// 
=// 
s2// 
.//  
Format//  &
,//& '
}00 
)00 
)00 
)00 
;00 
}11 	
private33 
void33 
CreateImportMap33 $
(33$ %
)33% &
{44 	
	CreateMap55 
<55 
AddImportDto55 "
,55" #
AddImportCommand55$ 4
>554 5
(555 6
)556 7
.66 
	ForMember66 
(66 
d66 
=>66 
d66  !
.66! "
Entity66" (
,66( )
o66* +
=>66, .
o66/ 0
.660 1
MapFrom661 8
(668 9
s669 :
=>66; =
new66> A
Import66B H
(66H I
)66I J
)66J K
)66K L
.77 
ForPath77 
(77 
d77 
=>77 
d77 
.77  
Entity77  &
.77& '
ImportItems77' 2
,772 3
o774 5
=>776 8
o779 :
.77: ;
MapFrom77; B
(77B C
s77C D
=>77E G.
"MapImportFileLinesToImportItemList77H j
(77j k
s77k l
.77l m
ImportFileLines77m |
)77| }
)77} ~
)77~ 
.88 
ForPath88 
(88 
d88 
=>88 
d88 
.88  
Entity88  &
.88& '
ImportLayoutId88' 5
,885 6
o887 8
=>889 ;
o88< =
.88= >
MapFrom88> E
(88E F
s88F G
=>88H J
s88K L
.88L M
ImportLayoutId88M [
)88[ \
)88\ ]
;88] ^
}99 	
private;; 
IEnumerable;; 
<;; 

ImportItem;; &
>;;& '.
"MapImportFileLinesToImportItemList;;( J
(;;J K
string;;K Q
importFileLines;;R a
);;a b
{<< 	
var== 
importItems== 
=== 
new== !
List==" &
<==& '

ImportItem==' 1
>==1 2
(==2 3
)==3 4
;==4 5
using?? 
(?? 
var?? 
reader?? 
=?? 
new??  #
StringReader??$ 0
(??0 1
importFileLines??1 @
)??@ A
)??A B
{@@ 
stringAA 
importFileLineAA %
;AA% &
whileBB 
(BB 
(BB 
importFileLineBB &
=BB' (
readerBB) /
.BB/ 0
ReadLineBB0 8
(BB8 9
)BB9 :
)BB: ;
!=BB< >
nullBB? C
)BBC D
{CC 
ifDD 
(DD 
!DD 
stringDD 
.DD  
IsNullOrEmptyDD  -
(DD- .
importFileLineDD. <
)DD< =
)DD= >
{EE 
importItemsFF #
.FF# $
AddFF$ '
(FF' (
newFF( +

ImportItemFF, 6
(FF6 7
)FF7 8
{FF9 :
ImportFileLineFF; I
=FFJ K
importFileLineFFL Z
}FF[ \
)FF\ ]
;FF] ^
}GG 
}HH 
}II 
returnKK 
importItemsKK 
;KK 
}LL 	
}MM 
}NN Ã

zC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\AutoMapper\EntityToDtoMappingProfile.cs
	namespace 	
	Something
 
. 
Application 
.  

AutoMapper  *
{ 
public		 

class		 %
EntityToDtoMappingProfile		 *
:		+ ,
Profile		- 4
{

 
public %
EntityToDtoMappingProfile (
(( )
)) *
{ 	
	CreateMap 
< 
Xpto 
, 
XptoDto #
># $
($ %
)% &
;& '
	CreateMap 
< 
ImportLayout "
," #
ImportLayoutDto$ 3
>3 4
(4 5
)5 6
;6 7
	CreateMap 
< 
ImportLayoutColumn (
,( )!
ImportLayoutColumnDto* ?
>? @
(@ A
)A B
;B C
	CreateMap 
< 
Import 
, 
	ImportDto '
>' (
(( )
)) *
;* +
	CreateMap 
< 

ImportItem  
,  !
ImportItemDto" /
>/ 0
(0 1
)1 2
;2 3
} 	
} 
} Æ
qC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\Common\ImportFieldRetriever.cs
	namespace 	
	Something
 
. 
Application 
.  
Common  &
{		 
public

 

class

  
ImportFieldRetriever

 %
:

& '!
IImportFieldRetriever

( =
{ 
public 
PropertyInfo 
[ 
] 
GetProperties +
(+ ,
ImportLayoutService, ?
service@ G
)G H
{ 	
var 
description 
= 
service %
.% &
GetDescription& 4
(4 5
)5 6
;6 7
var 
dtoType 
= 
Type 
. 
GetType &
(& '
description' 2
)2 3
;3 4
if 
( 
dtoType 
== 
null 
)  
{ 
return 
new 
List 
<  
PropertyInfo  ,
>, -
(- .
). /
./ 0
ToArray0 7
(7 8
)8 9
;9 :
} 
return 
dtoType 
. 
GetProperties (
(( )
)) *
;* +
} 	
} 
} ö
ÅC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\ImportDTOs\AddImportDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4

ImportDTOs4 >
{ 
public 

class 
AddImportDto 
: 
DataTransferObject  2
{ 
public 
Guid 
ImportLayoutId "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
string		 
ImportFileLines		 %
{		& '
get		( +
;		+ ,
set		- 0
;		0 1
}		2 3
}

 
} •
~C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\ImportDTOs\ImportDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4

ImportDTOs4 >
{ 
public 

class 
	ImportDto 
: 
DataTransferObject /
{		 
public

 
Guid

 
Id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 
int 
Code 
{ 
get 
; 
set "
;" #
}$ %
public 
ImportLayoutDto 
ImportLayout +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public 
bool 
	Processed 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
ItemsUnprocessed #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
int  
ItemsFailedProcessed '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
int &
ItemsSuccessfullyProcessed -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
IEnumerable 
< 
ImportItemDto (
>( )
ImportItems* 5
{6 7
get8 ;
;; <
set= @
;@ A
}B C
} 
} √
ÇC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\ImportDTOs\ImportItemDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4

ImportDTOs4 >
{ 
public 

class 
ImportItemDto 
:  
DataTransferObject! 3
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public		 
string		 
ImportFileLine		 $
{		% &
get		' *
;		* +
set		, /
;		/ 0
}		1 2
public

 
bool

 
	Processed

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Error 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ∆
ìC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\ImportLayoutDTOs\AddImportLayoutColumnDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4
ImportLayoutDTOs4 D
{ 
public 

class $
AddImportLayoutColumnDto )
:* +
DataTransferObject, >
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
Position 
{ 
get !
;! "
set# &
;& '
}( )
public		 
string		 
Format		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
} 
} ∞	
çC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\ImportLayoutDTOs\AddImportLayoutDto.cs
	namespace		 	
	Something		
 
.		 
Application		 
.		  
DataTransferObjects		  3
.		3 4
ImportLayoutDTOs		4 D
{

 
public 

class 
AddImportLayoutDto #
:$ %
DataTransferObject& 8
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
	Separator 
{  !
get" %
;% &
set' *
;* +
}, -
public 
ImportLayoutService "
Service# *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
IEnumerable 
< $
AddImportLayoutColumnDto 3
>3 4
Columns5 <
{= >
get? B
;B C
setD G
;G H
}I J
} 
} ‘
êC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\ImportLayoutDTOs\ImportLayoutColumnDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4
ImportLayoutDTOs4 D
{ 
public 

class !
ImportLayoutColumnDto &
:' (
DataTransferObject) ;
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
int

 
Position

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
string 
Format 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} –
äC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\ImportLayoutDTOs\ImportLayoutDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4
ImportLayoutDTOs4 D
{ 
public 

class 
ImportLayoutDto  
:! "
DataTransferObject# 5
{		 
public

 
Guid

 
Id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 
int 
Code 
{ 
get 
; 
set "
;" #
}$ %
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
	Separator 
{  !
get" %
;% &
set' *
;* +
}, -
public 
ImportLayoutService "
Service# *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
IEnumerable 
< !
ImportLayoutColumnDto 0
>0 1
Columns2 9
{: ;
get< ?
;? @
setA D
;D E
}F G
} 
} €
}C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\XptoDTOs\AddXptoDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4
XptoDtos4 <
{ 
[ 
ImportClass 
( 
Class 
= 
typeof 
(  
IXptoAppService  /
)/ 0
,0 1
Method2 8
=9 :
$str; @
)@ A
]A B
public		 

class		 

AddXptoDto		 
:		 
DataTransferObject		 0
{

 
[ 	
ImportField	 
( 
Name 
= 
$str  
)  !
]! "
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
ImportField	 
( 
Name 
= 
$str "
)" #
]# $
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
ImportField	 
( 
Name 
= 
$str %
)% &
]& '
public 
int 
Version 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
ImportField	 
( 
Name 
= 
$str #
)# $
]$ %
public 
double 
Value 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ‘

zC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\DataTransferObjects\XptoDTOs\XptoDto.cs
	namespace 	
	Something
 
. 
Application 
.  
DataTransferObjects  3
.3 4
XptoDtos4 <
{ 
public 

class 
XptoDto 
: 
DataTransferObject -
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public		 
int		 
Code		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 
string

 
Name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
Version 
{ 
get  
;  !
set" %
;% &
}' (
public 
double 
Value 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ˜
rC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\Interfaces\IImportAppService.cs
	namespace 	
	Something
 
. 
Application 
.  

Interfaces  *
{ 
public 

	interface 
IImportAppService &
:' (
IAppService) 4
<4 5
	ImportDto5 >
,> ?
AddImportDto@ L
>L M
{N O
}P Q
} è
xC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\Interfaces\IImportLayoutAppService.cs
	namespace 	
	Something
 
. 
Application 
.  

Interfaces  *
{ 
public 

	interface #
IImportLayoutAppService ,
:- .
IAppService/ :
<: ;
ImportLayoutDto; J
,J K
AddImportLayoutDtoL ^
>^ _
{` a
}b c
} Ô
pC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\Interfaces\IXptoAppService.cs
	namespace 	
	Something
 
. 
Application 
.  

Interfaces  *
{ 
public 

	interface 
IXptoAppService $
:% &
IAppService' 2
<2 3
XptoDto3 :
,: ;

AddXptoDto< F
>F G
{ 
} 
}		 ùM
oC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\Services\ImportAppService.cs
	namespace 	
	Something
 
. 
Application 
.  
Services  (
{ 
public 

class 
ImportAppService !
:" #

AppService$ .
<. /
	ImportDto/ 8
,8 9
AddImportDto: F
,F G
ImportH N
>N O
,O P
IImportAppService 
,  
INotificationHandler 
< 
ImportAddedEvent -
>- .
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IMediatorHandler )
	_mediator* 3
;3 4
private 
readonly 
IImportRepository *
_importRepository+ <
;< =
private 
readonly 
IServiceProvider )
_serviceProvider* :
;: ;
private 
readonly %
DomainNotificationHandler 2
_notifications3 A
;A B
public   
ImportAppService   
(    
IMapper    '
mapper  ( .
,  . /
IMediatorHandler!!  0
mediator!!1 9
,!!9 :
IImportRepository""  1
importRepository""2 B
,""B C
IServiceProvider##  0
serviceProvider##1 @
,##@ A 
INotificationHandler$$  4
<$$4 5
DomainNotification$$5 G
>$$G H
notifications$$I V
)$$V W
:%% 
base%% 
(%% 
mapper%% 
,%% 
importRepository%% +
)%%+ ,
{&& 	
_mapper'' 
='' 
mapper'' 
;'' 
	_mediator(( 
=(( 
mediator((  
;((  !
_importRepository)) 
=)) 
importRepository))  0
;))0 1
_serviceProvider** 
=** 
serviceProvider** .
;**. /
_notifications++ 
=++ 
(++ %
DomainNotificationHandler++ 7
)++7 8
notifications++8 E
;++E F
},, 	
public.. 
override.. 
async.. 
Task.. "
Add..# &
(..& '
AddImportDto..' 3
addImportDto..4 @
)..@ A
{// 	
await00 
	_mediator00 
.00 
SendCommand00 '
(00' (
_mapper00( /
.00/ 0
Map000 3
<003 4
AddImportCommand004 D
>00D E
(00E F
addImportDto00F R
)00R S
)00S T
;00T U
}11 	
public33 
async33 
Task33 
Handle33  
(33  !
ImportAddedEvent33! 1
notification332 >
,33> ?
CancellationToken33@ Q
cancellationToken33R c
)33c d
{44 	
var55 
import55 
=55 
await55 
_importRepository55 0
.550 1
GetById551 8
(558 9
notification559 E
.55E F
AggregateId55F Q
)55Q R
;55R S
var66 
importColumns66 
=66 
import66  &
.66& '
ImportLayout66' 3
.663 4
Columns664 ;
;66; <
var88 
importObjectType88  
=88! "
Type88# '
.88' (
GetType88( /
(88/ 0
import880 6
.886 7
ImportLayout887 C
.88C D
Service88D K
.88K L
GetDescription88L Z
(88Z [
)88[ \
)88\ ]
;88] ^
var99 
classAttribute99 
=99  
importObjectType99! 1
.991 2#
GetImportClassAttribute992 I
(99I J
)99J K
;99K L
var:: 
service:: 
=:: 
_serviceProvider:: *
.::* +

GetService::+ 5
(::5 6
classAttribute::6 D
.::D E
Class::E J
)::J K
;::K L
foreach<< 
(<< 
var<< 
item<< 
in<<  
import<<! '
.<<' (
ImportItems<<( 3
)<<3 4
{== 
var>> 
splitted>> 
=>> 
item>> #
.>># $
ImportFileLine>>$ 2
.>>2 3
Split>>3 8
(>>8 9
import>>9 ?
.>>? @
ImportLayout>>@ L
.>>L M
	Separator>>M V
)>>V W
;>>W X
if@@ 
(@@ 
splitted@@ 
.@@ 
Length@@ #
!=@@$ &
importColumns@@' 4
.@@4 5
Count@@5 :
(@@: ;
)@@; <
)@@< =
{AA 
itemBB 
.BB 
ErrorBB 
=BB  
stringBB! '
.BB' (
JoinBB( ,
(BB, -
$strBB- 1
,BB1 2
$strBB3 b
)BBb c
;BBc d
}CC 
elseDD 
{EE 
varFF 
instanceFF  
=FF! "
importObjectTypeFF# 3
.FF3 4
CreateInstanceFF4 B
(FFB C
)FFC D
;FFD E
foreachHH 
(HH 
varHH  
columnHH! '
inHH( *
importColumnsHH+ 8
)HH8 9
{II 
tryJJ 
{KK 
varLL 
propertyLL  (
=LL) *
importObjectTypeLL+ ;
.LL; <#
GetPropertyByImportNameLL< S
(LLS T
columnLLT Z
.LLZ [
NameLL[ _
)LL_ `
;LL` a
propertyMM $
.MM$ %
SetValueByStringMM% 5
(MM5 6
instanceMM6 >
,MM> ?
splittedMM@ H
[MMH I
columnMMI O
.MMO P
PositionMMP X
-MMY Z
$numMM[ \
]MM\ ]
,MM] ^
columnMM_ e
.MMe f
FormatMMf l
)MMl m
;MMm n
}NN 
catchOO 
(OO 
ImporterExceptionOO 0
exOO1 3
)OO3 4
{PP 
itemQQ  
.QQ  !
ErrorQQ! &
=QQ' (
exQQ) +
.QQ+ ,
MessageQQ, 3
;QQ3 4
}RR 
}SS 
ifUU 
(UU 
stringUU 
.UU 
IsNullOrEmptyUU ,
(UU, -
itemUU- 1
.UU1 2
ErrorUU2 7
)UU7 8
)UU8 9
{VV 
awaitWW 
serviceWW %
.WW% &

CallMethodWW& 0
(WW0 1
classAttributeWW1 ?
.WW? @
MethodWW@ F
,WWF G
instanceWWH P
)WWP Q
;WWQ R
ifYY 
(YY 
_notificationsYY *
.YY* +
HasNotificationsYY+ ;
(YY; <
)YY< =
)YY= >
{ZZ 
item[[  
.[[  !
Error[[! &
=[[' (
string[[) /
.[[/ 0
Join[[0 4
([[4 5
$str[[5 9
,[[9 :
_notifications[[; I
.[[I J
GetNotifications[[J Z
([[Z [
)[[[ \
.[[\ ]
Select[[] c
([[c d
c[[d e
=>[[f h
c[[i j
.[[j k
Value[[k p
)[[p q
)[[q r
;[[r s
}\\ 
}]] 
}^^ 
item`` 
.`` 
	Processed`` 
=``  
true``! %
;``% &
_notificationsaa 
.aa 
ClearNotificationsaa 1
(aa1 2
)aa2 3
;aa3 4
}bb 
importdd 
.dd &
ItemsSuccessfullyProcesseddd -
=dd. /
importdd0 6
.dd6 7
ImportItemsdd7 B
.ddB C
CountddC H
(ddH I
xddI J
=>ddK M
xddN O
.ddO P
	ProcessedddP Y
&&ddZ \
stringdd] c
.ddc d
IsNullOrEmptyddd q
(ddq r
xddr s
.dds t
Errorddt y
)ddy z
)ddz {
;dd{ |
importee 
.ee  
ItemsFailedProcessedee '
=ee( )
importee* 0
.ee0 1
ImportItemsee1 <
.ee< =
Countee= B
(eeB C
xeeC D
=>eeE G
xeeH I
.eeI J
	ProcessedeeJ S
&&eeT V
!eeW X
stringeeX ^
.ee^ _
IsNullOrEmptyee_ l
(eel m
xeem n
.een o
Erroreeo t
)eet u
)eeu v
;eev w
importff 
.ff 
ItemsUnprocessedff #
=ff$ %
importff& ,
.ff, -
ImportItemsff- 8
.ff8 9
Countff9 >
(ff> ?
xff? @
=>ffA C
!ffD E
xffE F
.ffF G
	ProcessedffG P
)ffP Q
;ffQ R
importgg 
.gg 
	Processedgg 
=gg 
importgg %
.gg% &
ItemsUnprocessedgg& 6
==gg7 9
$numgg: ;
;gg; <
ifii 
(ii 
!ii 
awaitii 
_importRepositoryii (
.ii( )

UnitOfWorkii) 3
.ii3 4
Commitii4 :
(ii: ;
)ii; <
)ii< =
{jj 
awaitkk 
	_mediatorkk 
.kk  %
PublishDomainNotificationkk  9
(kk9 :
newkk: =
DomainNotificationkk> P
(kkP Q
$strkkQ Y
,kkY Z
DomainMessagesll "
.ll" #
CommitFailedll# /
.ll/ 0
Messagell0 7
)ll7 8
)ll8 9
;ll9 :
}mm 
}nn 	
}oo 
}pp î
uC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\Services\ImportLayoutAppService.cs
	namespace 	
	Something
 
. 
Application 
.  
Services  (
{ 
public 

class "
ImportLayoutAppService '
:( )

AppService* 4
<4 5
ImportLayoutDto5 D
,D E
AddImportLayoutDtoF X
,X Y
ImportLayoutZ f
>f g
,g h#
IImportLayoutAppService 
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IMediatorHandler )
	_mediator* 3
;3 4
public "
ImportLayoutAppService %
(% &
IMapper& -
mapper. 4
,4 5
IMediatorHandler& 6
mediator7 ?
,? @#
IImportLayoutRepository& ="
importLayoutRepository> T
)T U
: 
base 
( 
mapper 
, "
importLayoutRepository 1
)1 2
{ 	
_mapper 
= 
mapper 
; 
	_mediator 
= 
mediator  
;  !
} 	
public 
override 
async 
Task "
Add# &
(& '
AddImportLayoutDto' 9
addImportLayoutDto: L
)L M
{ 	
await 
	_mediator 
. 
SendCommand '
(' (
_mapper( /
./ 0
Map0 3
<3 4"
AddImportLayoutCommand4 J
>J K
(K L
addImportLayoutDtoL ^
)^ _
)_ `
;` a
} 	
}   
}!! Ì
mC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Application\Services\XptoAppService.cs
	namespace 	
	Something
 
. 
Application 
.  
Services  (
{ 
public 

class 
XptoAppService 
:  !

AppService" ,
<, -
XptoDto- 4
,4 5

AddXptoDto6 @
,@ A
XptoB F
>F G
,G H
IXptoAppService 
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IMediatorHandler )
	_mediator* 3
;3 4
private 
readonly 
IServiceProvider )
_serviceProvider* :
;: ;
public 
XptoAppService 
( 
IMapper %
mapper& ,
,, -
IMediatorHandler .
mediator/ 7
,7 8
IXptoRepository -
xptoRepository. <
,< =
IServiceProvider .
serviceProvider/ >
)> ?
: 
base 
( 
mapper 
, 
xptoRepository )
)) *
{ 	
_mapper 
= 
mapper 
; 
	_mediator   
=   
mediator    
;    !
_serviceProvider!! 
=!! 
serviceProvider!! .
;!!. /
}"" 	
public$$ 
XptoAppService$$ 
($$ 
IMapper$$ %
mapper$$& ,
,$$, -
IMediatorHandler%% .
mediator%%/ 7
,%%7 8
IXptoRepository&& -
xptoRepository&&. <
)&&< =
:'' 
base'' 
('' 
mapper'' 
,'' 
xptoRepository'' )
)'') *
{(( 	
_mapper)) 
=)) 
mapper)) 
;)) 
	_mediator** 
=** 
mediator**  
;**  !
}++ 	
public-- 
override-- 
async-- 
Task-- "
Add--# &
(--& '

AddXptoDto--' 1

addXptoDto--2 <
)--< =
{.. 	
await// 
	_mediator// 
.// 
SendCommand// '
(//' (
_mapper//( /
./// 0
Map//0 3
<//3 4
AddXptoCommand//4 B
>//B C
(//C D

addXptoDto//D N
)//N O
)//O P
;//P Q
}00 	
}11 
}22 