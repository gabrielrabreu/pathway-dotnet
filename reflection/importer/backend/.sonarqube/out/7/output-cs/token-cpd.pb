œ%
uC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\CommandHandlers\ImportCommandHandler.cs
	namespace 	
	Something
 
. 
Domain 
. 
CommandHandlers *
{ 
public 

class  
ImportCommandHandler %
:& '
CommandHandler( 6
,6 7
IRequestHandler 
< 
AddImportCommand (
,( )
Unit* .
>. /
{ 
private 
readonly 
IMediatorHandler )
_mediatorHandler* :
;: ;
private 
readonly #
IImportLayoutRepository 0#
_importLayoutRepository1 H
;H I
private 
readonly 
IImportRepository *
_importRepository+ <
;< =
public  
ImportCommandHandler #
(# $
IMediatorHandler$ 4
mediatorHandler5 D
,D E 
INotificationHandler$ 8
<8 9
DomainNotification9 K
>K L
notificationsM Z
,Z [#
IImportLayoutRepository$ ;"
importLayoutRepository< R
,R S
IImportRepository$ 5
importRepository6 F
)F G
: 
base 
( 
mediatorHandler "
," #
notifications$ 1
)1 2
{ 	
_mediatorHandler 
= 
mediatorHandler .
;. /#
_importLayoutRepository   #
=  $ %"
importLayoutRepository  & <
;  < =
_importRepository!! 
=!! 
importRepository!!  0
;!!0 1
}"" 	
public$$ 
async$$ 
Task$$ 
<$$ 
Unit$$ 
>$$ 
Handle$$  &
($$& '
AddImportCommand$$' 7
request$$8 ?
,$$? @
CancellationToken$$A R
cancellationToken$$S d
)$$d e
{%% 	
if&& 
(&& 
!&& 
request&& 
.&& 
IsValid&&  
(&&  !
)&&! "
)&&" #
{'' 
await(( #
PublishValidationErrors(( -
(((- .
request((. 5
)((5 6
;((6 7
return)) 
Unit)) 
.)) 
Value)) !
;))! "
}** 
if,, 
(,, 
!,, 
(,, 
await,, #
_importLayoutRepository,, /
.,,/ 0
Search,,0 6
(,,6 7
x,,7 8
=>,,9 ;
x,,< =
.,,= >
Id,,> @
==,,A C
request,,D K
.,,K L
Entity,,L R
.,,R S
ImportLayoutId,,S a
),,a b
),,b c
.,,c d
Any,,d g
(,,g h
),,h i
),,i j
{-- 
await.. 
_mediatorHandler.. &
...& '%
PublishDomainNotification..' @
(..@ A
new..A D
DomainNotification..E W
(..W X
request..X _
..._ `
MessageType..` k
,..k l
DomainMessages// "
.//" #
NotFound//# +
.//+ ,
Format//, 2
(//2 3
$str//3 A
)//A B
.//B C
Message//C J
)//J K
)//K L
;//L M
return00 
Unit00 
.00 
Value00 !
;00! "
}11 
request33 
.33 
Entity33 
.33 
Date33 
=33  !
DateTime33" *
.33* +
UtcNow33+ 1
;331 2
request44 
.44 
Entity44 
.44 
ItemsUnprocessed44 +
=44, -
request44. 5
.445 6
Entity446 <
.44< =
ImportItems44= H
.44H I
Count44I N
(44N O
)44O P
;44P Q
_importRepository55 
.55 
Add55 !
(55! "
request55" )
.55) *
Entity55* 0
)550 1
;551 2
if77 
(77 
await77 
Commit77 
(77 
_importRepository77 .
.77. /

UnitOfWork77/ 9
)779 :
)77: ;
{88 
await99 
_mediatorHandler99 &
.99& '
PublishEvent99' 3
(993 4
new994 7
ImportAddedEvent998 H
(99H I
request99I P
.99P Q
Entity99Q W
.99W X
Id99X Z
)99Z [
)99[ \
;99\ ]
}:: 
return<< 
Unit<< 
.<< 
Value<< 
;<< 
}== 	
}>> 
}?? âj
{C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\CommandHandlers\ImportLayoutCommandHandler.cs
	namespace 	
	Something
 
. 
Domain 
. 
CommandHandlers *
{ 
public 

class &
ImportLayoutCommandHandler +
:, -
CommandHandler. <
,< =
IRequestHandler 
< "
AddImportLayoutCommand .
,. /
Unit0 4
>4 5
{ 
private 
readonly 
IMediatorHandler )
_mediatorHandler* :
;: ;
private 
readonly #
IImportLayoutRepository 0#
_importLayoutRepository1 H
;H I
private 
readonly !
IImportFieldRetriever .!
_importFieldRetriever/ D
;D E
public &
ImportLayoutCommandHandler )
() *
IMediatorHandler* :
mediatorHandler; J
,J K 
INotificationHandler* >
<> ?
DomainNotification? Q
>Q R
notificationsS `
,` a#
IImportLayoutRepository* A"
importLayoutRepositoryB X
,X Y!
IImportFieldRetriever  * ? 
importFieldRetriever  @ T
)  T U
:!! 
base!! 
(!! 
mediatorHandler!! "
,!!" #
notifications!!$ 1
)!!1 2
{"" 	
_mediatorHandler## 
=## 
mediatorHandler## .
;##. /#
_importLayoutRepository$$ #
=$$$ %"
importLayoutRepository$$& <
;$$< =!
_importFieldRetriever%% !
=%%" # 
importFieldRetriever%%$ 8
;%%8 9
}&& 	
public(( 
async(( 
Task(( 
<(( 
Unit(( 
>(( 
Handle((  &
(((& '"
AddImportLayoutCommand((' =
request((> E
,((E F
CancellationToken((G X
cancellationToken((Y j
)((j k
{)) 	
if** 
(** 
!** 
request** 
.** 
IsValid**  
(**  !
)**! "
)**" #
{++ 
await,, #
PublishValidationErrors,, -
(,,- .
request,,. 5
),,5 6
;,,6 7
return-- 
Unit-- 
.-- 
Value-- !
;--! "
}.. 
if00 
(00 
(00 
await00 #
_importLayoutRepository00 .
.00. /
Search00/ 5
(005 6
x006 7
=>008 :
x00; <
.00< =
Name00= A
==00B D
request00E L
.00L M
Entity00M S
.00S T
Name00T X
)00X Y
)00Y Z
.00Z [
Any00[ ^
(00^ _
)00_ `
)00` a
{11 
await22 
_mediatorHandler22 &
.22& '%
PublishDomainNotification22' @
(22@ A
new22A D
DomainNotification22E W
(22W X
request22X _
.22_ `
MessageType22` k
,22k l
DomainMessages33 "
.33" #
AlreadyInUse33# /
.33/ 0
Format330 6
(336 7
$str337 =
)33= >
.33> ?
Message33? F
)33F G
)33G H
;33H I
return44 
Unit44 
.44 
Value44 !
;44! "
}55 
if77 
(77 
!77 
await77 $
ValidateIfColumsAreValid77 /
(77/ 0
request770 7
.777 8
MessageType778 C
,77C D
request77E L
.77L M
Entity77M S
.77S T
Service77T [
,77[ \
request77] d
.77d e
Entity77e k
.77k l
Columns77l s
)77s t
)77t u
{88 
return99 
Unit99 
.99 
Value99 !
;99! "
}:: #
_importLayoutRepository<< #
.<<# $
Add<<$ '
(<<' (
request<<( /
.<</ 0
Entity<<0 6
)<<6 7
;<<7 8
await>> 
Commit>> 
(>> #
_importLayoutRepository>> 0
.>>0 1

UnitOfWork>>1 ;
)>>; <
;>>< =
return@@ 
Unit@@ 
.@@ 
Value@@ 
;@@ 
}AA 	
privateCC 
asyncCC 
TaskCC 
<CC 
boolCC 
>CC  $
ValidateIfColumsAreValidCC! 9
(CC9 :
stringCC: @
messageTypeCCA L
,CCL M
ImportLayoutServiceDD: M
importLayoutServiceDDN a
,DDa b
IEnumerableEE: E
<EEE F
ImportLayoutColumnEEF X
>EEX Y
importLayoutColumnsEEZ m
)EEm n
{FF 	
ifGG 
(GG 
!GG 
awaitGG -
!ValidateIfColumnsPositionAreValidGG 8
(GG8 9
messageTypeGG9 D
,GGD E
importLayoutColumnsGGF Y
)GGY Z
)GGZ [
{HH 
returnII 
falseII 
;II 
}JJ 
ifLL 
(LL 
!LL 
awaitLL &
ValidateIfColumnNameRepeatLL 1
(LL1 2
messageTypeLL2 =
,LL= >
importLayoutColumnsLL? R
)LLR S
)LLS T
{MM 
returnNN 
falseNN 
;NN 
}OO 
ifQQ 
(QQ 
!QQ 
awaitQQ &
ValidateIfColumnNameExistsQQ 1
(QQ1 2
messageTypeQQ2 =
,QQ= >
importLayoutServiceQQ? R
,QQR S
importLayoutColumnsQQT g
)QQg h
)QQh i
{RR 
returnSS 
falseSS 
;SS 
}TT 
returnVV 
trueVV 
;VV 
}WW 	
privateYY 
asyncYY 
TaskYY 
<YY 
boolYY 
>YY  -
!ValidateIfColumnsPositionAreValidYY! B
(YYB C
stringYYC I
messageTypeYYJ U
,YYU V
IEnumerableZZC N
<ZZN O
ImportLayoutColumnZZO a
>ZZa b
importLayoutColumnsZZc v
)ZZv w
{[[ 	
var\\ 
	positions\\ 
=\\ 
importLayoutColumns\\ /
.\\/ 0
Select\\0 6
(\\6 7
x\\7 8
=>\\9 ;
x\\< =
.\\= >
Position\\> F
)\\F G
;\\G H
if^^ 
(^^ 
!^^ 
	positions^^ 
.^^ 
Any^^ 
(^^ 
x^^  
=>^^! #
x^^$ %
==^^& (
$num^^) *
)^^* +
)^^+ ,
{__ 
await`` 
_mediatorHandler`` &
.``& '%
PublishDomainNotification``' @
(``@ A
new``A D
DomainNotification``E W
(``W X
messageType``X c
,``c d
$straa =
)aa= >
)aa> ?
;aa? @
returnbb 
falsebb 
;bb 
}cc 
varee 
isConsecutiveee 
=ee 
!ee  !
	positionsee! *
.ee* +
Selectee+ 1
(ee1 2
(ee2 3
iee3 4
,ee4 5
jee6 7
)ee7 8
=>ee9 ;
iee< =
-ee> ?
jee@ A
)eeA B
.eeB C
DistincteeC K
(eeK L
)eeL M
.eeM N
SkipeeN R
(eeR S
$numeeS T
)eeT U
.eeU V
AnyeeV Y
(eeY Z
)eeZ [
;ee[ \
ifff 
(ff 
!ff 
isConsecutiveff 
)ff 
{gg 
awaithh 
_mediatorHandlerhh &
.hh& '%
PublishDomainNotificationhh' @
(hh@ A
newhhA D
DomainNotificationhhE W
(hhW X
messageTypehhX c
,hhc d
$strii ;
)ii; <
)ii< =
;ii= >
returnjj 
falsejj 
;jj 
}kk 
returnmm 
truemm 
;mm 
}nn 	
privatepp 
asyncpp 
Taskpp 
<pp 
boolpp 
>pp  &
ValidateIfColumnNameRepeatpp! ;
(pp; <
stringpp< B
messageTypeppC N
,ppN O
IEnumerableqq< G
<qqG H
ImportLayoutColumnqqH Z
>qqZ [
importLayoutColumnsqq\ o
)qqo p
{rr 	
ifss 
(ss 
importLayoutColumnsss #
.ss# $
Countss$ )
(ss) *
)ss* +
!=ss, .
importLayoutColumnsss/ B
.ssB C
GroupByssC J
(ssJ K
xssK L
=>ssM O
xssP Q
.ssQ R
NamessR V
)ssV W
.ssW X
CountssX ]
(ss] ^
)ss^ _
)ss_ `
{tt 
awaituu 
_mediatorHandleruu &
.uu& '%
PublishDomainNotificationuu' @
(uu@ A
newuuA D
DomainNotificationuuE W
(uuW X
messageTypeuuX c
,uuc d
$strvv 1
)vv1 2
)vv2 3
;vv3 4
returnww 
falseww 
;ww 
}xx 
returnzz 
truezz 
;zz 
}{{ 	
private}} 
async}} 
Task}} 
<}} 
bool}} 
>}}  &
ValidateIfColumnNameExists}}! ;
(}}; <
string}}< B
messageType}}C N
,}}N O
ImportLayoutService~~< O
importLayoutService~~P c
,~~c d
IEnumerable< G
<G H
ImportLayoutColumnH Z
>Z [
importLayoutColumns\ o
)o p
{
ÄÄ 	
var
ÅÅ 

properties
ÅÅ 
=
ÅÅ #
_importFieldRetriever
ÅÅ 2
.
ÅÅ2 3
GetProperties
ÅÅ3 @
(
ÅÅ@ A!
importLayoutService
ÅÅA T
)
ÅÅT U
;
ÅÅU V
foreach
ÉÉ 
(
ÉÉ 
var
ÉÉ 
column
ÉÉ 
in
ÉÉ  "!
importLayoutColumns
ÉÉ# 6
)
ÉÉ6 7
{
ÑÑ 
var
ÖÖ 
columnWasFound
ÖÖ "
=
ÖÖ# $
false
ÖÖ% *
;
ÖÖ* +
foreach
áá 
(
áá 
var
áá 
property
áá %
in
áá& (

properties
áá) 3
)
áá3 4
{
àà 
var
ââ 
customAttribute
ââ '
=
ââ( )
property
ââ* 2
.
ââ2 3!
GetCustomAttributes
ââ3 F
(
ââF G
typeof
ââG M
(
ââM N"
ImportFieldAttribute
ââN b
)
ââb c
,
ââc d
false
ââe j
)
ââj k
.
ââk l
SingleOrDefault
ââl {
(
ââ{ |
)
ââ| }
;
ââ} ~
if
ää 
(
ää 
customAttribute
ää '
!=
ää( *
null
ää+ /
)
ää/ 0
{
ãã 
var
åå 
fieldAttribute
åå *
=
åå+ ,
(
åå- ."
ImportFieldAttribute
åå. B
)
ååB C
customAttribute
ååC R
;
ååR S
if
çç 
(
çç 
fieldAttribute
çç *
.
çç* +
Name
çç+ /
==
çç0 2
column
çç3 9
.
çç9 :
Name
çç: >
)
çç> ?
{
éé 
columnWasFound
èè *
=
èè+ ,
true
èè- 1
;
èè1 2
if
ëë 
(
ëë  
property
ëë  (
.
ëë( )
PropertyType
ëë) 5
==
ëë6 8
typeof
ëë9 ?
(
ëë? @
DateTime
ëë@ H
)
ëëH I
&&
ëëJ L
string
ëëM S
.
ëëS T
IsNullOrEmpty
ëëT a
(
ëëa b
column
ëëb h
.
ëëh i
Format
ëëi o
)
ëëo p
)
ëëp q
{
íí 
await
ìì  %
_mediatorHandler
ìì& 6
.
ìì6 7'
PublishDomainNotification
ìì7 P
(
ììP Q
new
ììQ T 
DomainNotification
ììU g
(
ììg h
messageType
ììh s
,
ììs t
$"
îî$ &
$str
îî& 3
{
îî3 4
column
îî4 :
.
îî: ;
Name
îî; ?
}
îî? @
$str
îî@ U
"
îîU V
)
îîV W
)
îîW X
;
îîX Y
return
ïï  &
false
ïï' ,
;
ïï, -
}
ññ 
break
òò !
;
òò! "
}
ôô 
}
öö 
}
õõ 
if
ùù 
(
ùù 
!
ùù 
columnWasFound
ùù #
)
ùù# $
{
ûû 
await
üü 
_mediatorHandler
üü *
.
üü* +'
PublishDomainNotification
üü+ D
(
üüD E
new
üüE H 
DomainNotification
üüI [
(
üü[ \
messageType
üü\ g
,
üüg h
$"
†† 
$str
†† '
{
††' (
column
††( .
.
††. /
Name
††/ 3
}
††3 4
$str
††4 K
{
††K L!
importLayoutService
††L _
}
††_ `
$str
††` b
"
††b c
)
††c d
)
††d e
;
††e f
return
°° 
false
°°  
;
°°  !
}
¢¢ 
}
££ 
return
•• 
true
•• 
;
•• 
}
¶¶ 	
}
ßß 
}®® ú
sC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\CommandHandlers\XptoCommandHandler.cs
	namespace 	
	Something
 
. 
Domain 
. 
CommandHandlers *
{ 
public 

class 
XptoCommandHandler #
:$ %
CommandHandler& 4
,4 5
IRequestHandler 
< 
AddXptoCommand &
,& '
Unit( ,
>, -
{ 
private 
readonly 
IMediatorHandler )
_mediatorHandler* :
;: ;
private 
readonly 
IXptoRepository (
_xptoRepository) 8
;8 9
public 
XptoCommandHandler !
(! "
IMediatorHandler" 2
mediatorHandler3 B
,B C 
INotificationHandler" 6
<6 7
DomainNotification7 I
>I J
notificationsK X
,X Y
IXptoRepository" 1
xptoRepository2 @
)@ A
: 
base 
( 
mediatorHandler "
," #
notifications$ 1
)1 2
{ 	
_mediatorHandler 
= 
mediatorHandler .
;. /
_xptoRepository 
= 
xptoRepository ,
;, -
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '
AddXptoCommand' 5
request6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 	
if 
( 
! 
request 
. 
IsValid  
(  !
)! "
)" #
{   
await!! #
PublishValidationErrors!! -
(!!- .
request!!. 5
)!!5 6
;!!6 7
return"" 
Unit"" 
."" 
Value"" !
;""! "
}## 
if%% 
(%% 
(%% 
await%% 
_xptoRepository%% &
.%%& '
Search%%' -
(%%- .
x%%. /
=>%%0 2
x%%3 4
.%%4 5
Name%%5 9
==%%: <
request%%= D
.%%D E
Entity%%E K
.%%K L
Name%%L P
)%%P Q
)%%Q R
.%%R S
Any%%S V
(%%V W
)%%W X
)%%X Y
{&& 
await'' 
_mediatorHandler'' &
.''& '%
PublishDomainNotification''' @
(''@ A
new''A D
DomainNotification''E W
(''W X
request''X _
.''_ `
MessageType''` k
,''k l
DomainMessages(( "
.((" #
AlreadyInUse((# /
.((/ 0
Format((0 6
(((6 7
$str((7 =
)((= >
.((> ?
Message((? F
)((F G
)((G H
;((H I
return)) 
Unit)) 
.)) 
Value)) !
;))! "
}** 
_xptoRepository,, 
.,, 
Add,, 
(,,  
request,,  '
.,,' (
Entity,,( .
),,. /
;,,/ 0
await.. 
Commit.. 
(.. 
_xptoRepository.. (
...( )

UnitOfWork..) 3
)..3 4
;..4 5
return00 
Unit00 
.00 
Value00 
;00 
}11 	
}22 
}33 è

yC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Commands\ImportCommands\AddImportCommand.cs
	namespace 	
	Something
 
. 
Domain 
. 
Commands #
.# $
ImportCommands$ 2
{ 
public 

class 
AddImportCommand !
:" #
Command$ +
{		 
public

 
Import

 
Entity

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
AddImportCommand 
(  
)  !
:" #
base$ (
(( )
Guid) -
.- .
Empty. 3
)3 4
{5 6
}7 8
public 
override 
bool 
IsValid $
($ %
)% &
{ 	
ValidationResult 
= 
new "%
AddImportCommandValidator# <
(< =
)= >
.> ?
Validate? G
(G H
thisH L
)L M
;M N
return 
ValidationResult #
.# $
IsValid$ +
;+ ,
} 	
} 
} ∫

ÖC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Commands\ImportLayoutCommands\AddImportLayoutCommand.cs
	namespace 	
	Something
 
. 
Domain 
. 
Commands #
.# $ 
ImportLayoutCommands$ 8
{ 
public 

class "
AddImportLayoutCommand '
:( )
Command* 1
{		 
public

 
ImportLayout

 
Entity

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
public "
AddImportLayoutCommand %
(% &
)& '
:( )
base* .
(. /
Guid/ 3
.3 4
Empty4 9
)9 :
{; <
}= >
public 
override 
bool 
IsValid $
($ %
)% &
{ 	
ValidationResult 
= 
new "+
AddImportLayoutCommandValidator# B
(B C
)C D
.D E
ValidateE M
(M N
thisN R
)R S
;S T
return 
ValidationResult #
.# $
IsValid$ +
;+ ,
} 	
} 
} Å

uC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Commands\XptoCommands\AddXptoCommand.cs
	namespace 	
	Something
 
. 
Domain 
. 
Commands #
.# $
XptoCommands$ 0
{ 
public 

class 
AddXptoCommand 
:  !
Command" )
{		 
public

 
Xpto

 
Entity

 
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
public 
AddXptoCommand 
( 
) 
:  !
base" &
(& '
Guid' +
.+ ,
Empty, 1
)1 2
{3 4
}5 6
public 
override 
bool 
IsValid $
($ %
)% &
{ 	
ValidationResult 
= 
new "#
AddXptoCommandValidator# :
(: ;
); <
.< =
Validate= E
(E F
thisF J
)J K
;K L
return 
ValidationResult #
.# $
IsValid$ +
;+ ,
} 	
} 
} ù
mC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Common\IImportFieldRetriever.cs
	namespace 	
	Something
 
. 
Domain 
. 
Common !
{ 
public 

	interface !
IImportFieldRetriever *
{ 
PropertyInfo 
[ 
] 
GetProperties $
($ %
ImportLayoutService% 8
service9 @
)@ A
;A B
}		 
}

 «
`C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Entities\Import.cs
	namespace 	
	Something
 
. 
Domain 
. 
Entities #
{ 
public 

class 
Import 
: 
Entity  
{ 
public		 
Guid		 
ImportLayoutId		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
public

 
DateTime

 
Date

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
bool 
	Processed 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
ItemsUnprocessed #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
int  
ItemsFailedProcessed '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
int &
ItemsSuccessfullyProcessed -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
virtual 
ImportLayout #
ImportLayout$ 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
IEnumerable 
< 

ImportItem %
>% &
ImportItems' 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} Ñ

dC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Entities\ImportItem.cs
	namespace 	
	Something
 
. 
Domain 
. 
Entities #
{ 
public 

class 

ImportItem 
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
public 
Guid 
ImportId 
{ 
get "
;" #
set$ '
;' (
}) *
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
}( )
public 
virtual 
Import 
Import $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} Ö

fC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Entities\ImportLayout.cs
	namespace 	
	Something
 
. 
Domain 
. 
Entities #
{ 
public 

class 
ImportLayout 
: 
Entity  &
{ 
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
 
string

 
	Separator

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
ImportLayoutService "
Service# *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
IEnumerable 
< 
ImportLayoutColumn -
>- .
Columns/ 6
{7 8
get9 <
;< =
set> A
;A B
}C D
public 
IEnumerable 
< 
Import !
>! "
Imports# *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
} õ

lC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Entities\ImportLayoutColumn.cs
	namespace 	
	Something
 
. 
Domain 
. 
Entities #
{ 
public 

class 
ImportLayoutColumn #
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
}) *
public 
virtual 
ImportLayout #
ImportLayout$ 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
} 
} À
^C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Entities\Xpto.cs
	namespace 	
	Something
 
. 
Domain 
. 
Entities #
{ 
public 

class 
Xpto 
: 
Entity 
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public		 
DateTime		 
Date		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
int

 
Version

 
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
public 
double 
Value 
{ 
get !
;! "
set# &
;& '
}( )
} 
} „
jC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Enums\ImportLayoutService.cs
	namespace 	
	Something
 
. 
Domain 
. 
Enums  
{ 
public 

enum 
ImportLayoutService #
{ 
[ 	
Description	 
( 
$str 
) 
] 

Uninformed 
, 
[		 	
Description			 
(		 
$str		 T
)		T U
]		U V
Xpto

 
} 
} ¢
uC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Events\ImportEvents\ImportAddedEvent.cs
	namespace 	
	Something
 
. 
Domain 
. 
Events !
.! "
ImportEvents" .
{ 
public 

class 
ImportAddedEvent !
:" #
Event$ )
{ 
public 
ImportAddedEvent 
(  
Guid  $
aggregateId% 0
)0 1
:2 3
base4 8
(8 9
aggregateId9 D
)D E
{F G
}H I
}		 
}

 ”
sC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Interfaces\IImportLayoutRepository.cs
	namespace 	
	Something
 
. 
Domain 
. 

Interfaces %
{ 
public 

	interface #
IImportLayoutRepository ,
:- .
IRepository/ :
<: ;
ImportLayout; G
>G H
{I J
}K L
} ¡
mC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Interfaces\IImportRepository.cs
	namespace 	
	Something
 
. 
Domain 
. 

Interfaces %
{ 
public 

	interface 
IImportRepository &
:' (
IRepository) 4
<4 5
Import5 ;
>; <
{= >
}? @
} ª
kC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Interfaces\IXptoRepository.cs
	namespace 	
	Something
 
. 
Domain 
. 

Interfaces %
{ 
public 

	interface 
IXptoRepository $
:% &
IRepository' 2
<2 3
Xpto3 7
>7 8
{9 :
}; <
} …
íC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Validators\ImportLayoutValidators\AddImportLayoutCommandValidator.cs
	namespace 	
	Something
 
. 
Domain 
. 

Validators %
.% &"
ImportLayoutValidators& <
{ 
public 

class +
AddImportLayoutCommandValidator 0
:1 2
CommandValidator3 C
<C D"
AddImportLayoutCommandD Z
>Z [
{		 
public

 +
AddImportLayoutCommandValidator

 .
(

. /
)

/ 0
{ 	
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Name" &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA G
)G H
.H I
MessageI P
)P Q
;Q R
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
	Separator" +
)+ ,
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA L
)L M
.M N
MessageN U
)U V
;V W
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Service" )
)) *
. 
IsInEnum 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
InvalidFormat, 9
.9 :
Format: @
(@ A
$strA J
)J K
.K L
MessageL S
)S T
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA J
)J K
.K L
MessageL S
)S T
;T U
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Columns" )
)) *
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA V
)V W
.W X
MessageX _
)_ `
;` a
RuleForEach 
( 
x 
=> 
x 
. 
Entity %
.% &
Columns& -
)- .
.. /
SetValidator/ ;
(; <
new< ?'
ImportLayoutColumnValidator@ [
([ \
)\ ]
)] ^
;^ _
} 	
}   
}!! †
éC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Validators\ImportLayoutValidators\ImportLayoutColumnValidator.cs
	namespace 	
	Something
 
. 
Domain 
. 

Validators %
.% &"
ImportLayoutValidators& <
{ 
public 

class '
ImportLayoutColumnValidator ,
:- .
AbstractValidator/ @
<@ A
ImportLayoutColumnA S
>S T
{ 
public		 '
ImportLayoutColumnValidator		 *
(		* +
)		+ ,
{

 	
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA G
)G H
.H I
MessageI P
)P Q
;Q R
RuleFor 
( 
x 
=> 
x 
. 
Position #
)# $
.  
GreaterThanOrEqualTo %
(% &
$num& '
)' (
. 
WithMessage 
( 
DomainMessages +
.+ ,!
MustBeGreatherOrEqual, A
.A B
FormatB H
(H I
$strI S
,S T
$numU V
)V W
.W X
MessageX _
)_ `
;` a
} 	
} 
} ó
ÜC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Validators\ImportValidators\AddImportCommandValidator.cs
	namespace 	
	Something
 
. 
Domain 
. 

Validators %
.% &
ImportValidators& 6
{ 
public 

class %
AddImportCommandValidator *
:+ ,
CommandValidator- =
<= >
AddImportCommand> N
>N O
{		 
public

 %
AddImportCommandValidator

 (
(

( )
)

) *
{ 	
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
ImportLayoutId" 0
)0 1
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA Q
)Q R
.R S
MessageS Z
)Z [
;[ \
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
ImportItems" -
)- .
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA N
)N O
.O P
MessageP W
)W X
;X Y
} 	
} 
} Ä
ÇC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Domain\Validators\XptoValidators\AddXptoCommandValidator.cs
	namespace 	
	Something
 
. 
Domain 
. 

Validators %
.% &
XptoValidators& 4
{ 
public 

class #
AddXptoCommandValidator (
:) *
CommandValidator+ ;
<; <
AddXptoCommand< J
>J K
{		 
public

 #
AddXptoCommandValidator

 &
(

& '
)

' (
{ 	
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Name" &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA G
)G H
.H I
MessageI P
)P Q
;Q R
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Date" &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA G
)G H
.H I
MessageI P
)P Q
;Q R
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Version" )
)) *
.  
GreaterThanOrEqualTo %
(% &
$num& '
)' (
. 
WithMessage 
( 
DomainMessages +
.+ ,!
MustBeGreatherOrEqual, A
.A B
FormatB H
(H I
$strI R
,R S
$numT U
)U V
.V W
MessageW ^
)^ _
;_ `
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Value" '
)' (
.  
GreaterThanOrEqualTo %
(% &
$num& '
)' (
. 
WithMessage 
( 
DomainMessages +
.+ ,!
MustBeGreatherOrEqual, A
.A B
FormatB H
(H I
$strI P
,P Q
$numR S
)S T
.T U
MessageU \
)\ ]
;] ^
} 	
} 
} 