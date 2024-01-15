²
wC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\GenericImporter.Service\Attributes\ImportClassAttribute.cs
	namespace 	
GenericImporter
 
. 
Service !
.! "

Attributes" ,
{ 
[ 
AttributeUsage 
( 
AttributeTargets $
.$ %
Class% *
,* +
AllowMultiple, 9
=: ;
false< A
)A B
]B C
public 

class  
ImportClassAttribute %
:& '
	Attribute( 1
{ 
public		 
Type		 
Class		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
public

 
string

 
Method
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
) *
} 
} œ
wC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\GenericImporter.Service\Attributes\ImportFieldAttribute.cs
	namespace 	
GenericImporter
 
. 
Service !
.! "

Attributes" ,
{ 
[ 
AttributeUsage 
( 
AttributeTargets $
.$ %
Property% -
,- .
AllowMultiple/ <
== >
false? D
)D E
]E F
public 

class  
ImportFieldAttribute %
:& '
	Attribute( 1
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
}		 
}

 Û
tC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\GenericImporter.Service\Exceptions\ImporterException.cs
	namespace 	
GenericImporter
 
. 
Service !
.! "

Exceptions" ,
{ 
[ 
System 
. 
Diagnostics 
. 
CodeAnalysis $
.$ %
SuppressMessage% 4
(4 5
$str5 G
,G H
$str	I ‚
,
‚ ƒ
Justification
„ ‘
=
’ “
$str
” Ÿ
)
Ÿ  
]
  ¡
public 

class 
ImporterException "
:# $
	Exception% .
{ 
public 
ImporterException  
(  !
string! '
message( /
)/ 0
:1 2
base3 7
(7 8
message8 ?
)? @
{A B
}C D
}		 
}

 °
sC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\GenericImporter.Service\Extensions\ObjectExtensions.cs
	namespace 	
GenericImporter
 
. 
Service !
.! "

Extensions" ,
{ 
public 

static 
class 
ObjectExtensions (
{ 
public 
static 
async 
Task  

CallMethod! +
(+ ,
this, 0
object1 7
service8 ?
,? @
stringA G

methodNameH R
,R S
objectT Z
	parameter[ d
)d e
{		 	
var

 
method

 
=

 
service

  
.

  !
GetType

! (
(

( )
)

) *
.

* + 
GetMethodOfInterface

+ ?
(

? @

methodName

@ J
)

J K
;

K L
var 
convertedParameter "
=# $
Convert% ,
., -

ChangeType- 7
(7 8
	parameter8 A
,A B
	parameterC L
.L M
GetTypeM T
(T U
)U V
)V W
;W X
var 
invoke 
= 
method 
.  
Invoke  &
(& '
service' .
,. /
new0 3
object4 :
[: ;
]; <
{= >
convertedParameter? Q
}R S
)S T
;T U
await 
( 
invoke 
as 
Task !
)! "
;" #
} 	
} 
} ëE
yC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\GenericImporter.Service\Extensions\PropertyInfoExtensions.cs
	namespace 	
GenericImporter
 
. 
Service !
.! "

Extensions" ,
{		 
public

 

static

 
class

 "
PropertyInfoExtensions

 .
{ 
public 
static  
ImportFieldAttribute *
GetImportAttribute+ =
(= >
this> B
PropertyInfoC O
propertyInfoP \
)\ ]
{ 	
var 
customAttribute 
=  !
propertyInfo" .
.. /
GetCustomAttributes/ B
(B C
typeofC I
(I J 
ImportFieldAttributeJ ^
)^ _
,_ `
falsea f
)f g
.g h
SingleOrDefaulth w
(w x
)x y
;y z
if 
( 
customAttribute 
!=  "
null# '
)' (
{ 
return 
(  
ImportFieldAttribute ,
), -
customAttribute- <
;< =
} 
return 
null 
; 
} 	
public 
static 
void 
SetValueByString +
(+ ,
this, 0
PropertyInfo1 =
propertyInfo> J
,J K
objectL R
instanceS [
,[ \
string] c
valued i
,i j
stringk q
formatr x
=y z
null{ 
)	 €
{ 	
if 
( 
typeof 
( 
int 
) 
== 
propertyInfo +
.+ ,
PropertyType, 8
)8 9
{ 
propertyInfo 
. %
SetIntegerValueFromString 6
(6 7
instance7 ?
,? @
valueA F
)F G
;G H
} 
else 
if 
( 
typeof 
( 
double "
)" #
==$ &
propertyInfo' 3
.3 4
PropertyType4 @
)@ A
{ 
propertyInfo   
.   $
SetDoubleValueFromString   5
(  5 6
instance  6 >
,  > ?
value  @ E
)  E F
;  F G
}!! 
else"" 
if"" 
("" 
typeof"" 
("" 
DateTime"" $
)""$ %
==""& (
propertyInfo"") 5
.""5 6
PropertyType""6 B
)""B C
{## 
propertyInfo$$ 
.$$ &
SetDateTimeValueFromString$$ 7
($$7 8
instance$$8 @
,$$@ A
value$$B G
,$$G H
format$$I O
)$$O P
;$$P Q
}%% 
else&& 
if&& 
(&& 
typeof&& 
(&& 
Guid&&  
)&&  !
==&&" $
propertyInfo&&% 1
.&&1 2
PropertyType&&2 >
)&&> ?
{'' 
propertyInfo(( 
.(( "
SetGuidValueFromString(( 3
(((3 4
instance((4 <
,((< =
value((> C
)((C D
;((D E
})) 
else** 
{++ 
propertyInfo,, 
.,, 
SetValue,, %
(,,% &
instance,,& .
,,,. /
value,,0 5
),,5 6
;,,6 7
}-- 
}.. 	
public00 
static00 
void00 %
SetIntegerValueFromString00 4
(004 5
this005 9
PropertyInfo00: F
propertyInfo00G S
,00S T
object00U [
instance00\ d
,00d e
string00f l
value00m r
)00r s
{11 	
if22 
(22 
int22 
.22 
TryParse22 
(22 
value22 "
,22" #
out22$ '
_22( )
)22) *
)22* +
{33 
var44 
convertedValue44 "
=44# $
int44% (
.44( )
Parse44) .
(44. /
value44/ 4
)444 5
;445 6
propertyInfo55 
.55 
SetValue55 %
(55% &
instance55& .
,55. /
convertedValue550 >
)55> ?
;55? @
return66 
;66 
}77 
throw99 
new99 
ImporterException99 '
(99' (
$"99( *
$str99* >
{99> ?
propertyInfo99? K
.99K L
Name99L P
}99P Q
$str99Q j
"99j k
)99k l
;99l m
}:: 	
public<< 
static<< 
void<< $
SetDoubleValueFromString<< 3
(<<3 4
this<<4 8
PropertyInfo<<9 E
propertyInfo<<F R
,<<R S
object<<T Z
instance<<[ c
,<<c d
string<<e k
value<<l q
)<<q r
{== 	
if>> 
(>> 
double>> 
.>> 
TryParse>> 
(>>  
value>>  %
,>>% &
out>>' *
_>>+ ,
)>>, -
)>>- .
{?? 
var@@ 
convertedValue@@ "
=@@# $
double@@% +
.@@+ ,
Parse@@, 1
(@@1 2
value@@2 7
)@@7 8
;@@8 9
propertyInfoAA 
.AA 
SetValueAA %
(AA% &
instanceAA& .
,AA. /
convertedValueAA0 >
)AA> ?
;AA? @
returnBB 
;BB 
}CC 
throwEE 
newEE 
ImporterExceptionEE '
(EE' (
$"EE( *
$strEE* >
{EE> ?
propertyInfoEE? K
.EEK L
NameEEL P
}EEP Q
$strEEQ i
"EEi j
)EEj k
;EEk l
}FF 	
publicHH 
staticHH 
voidHH &
SetDateTimeValueFromStringHH 5
(HH5 6
thisHH6 :
PropertyInfoHH; G
propertyInfoHHH T
,HHT U
objectHHV \
instanceHH] e
,HHe f
stringHHg m
valueHHn s
,HHs t
stringHHu {
format	HH| ‚
)
HH‚ ƒ
{II 	
ifJJ 
(JJ 
DateTimeJJ 
.JJ 
TryParseExactJJ &
(JJ& '
valueJJ' ,
,JJ, -
formatJJ. 4
,JJ4 5
CultureInfoJJ6 A
.JJA B
InvariantCultureJJB R
,JJR S
DateTimeStylesJJT b
.JJb c
NoneJJc g
,JJg h
outJJi l
_JJm n
)JJn o
)JJo p
{KK 
varLL 
convertedValueLL "
=LL# $
DateTimeLL% -
.LL- .

ParseExactLL. 8
(LL8 9
valueLL9 >
,LL> ?
formatLL@ F
,LLF G
CultureInfoLLH S
.LLS T
InvariantCultureLLT d
)LLd e
;LLe f
propertyInfoMM 
.MM 
SetValueMM %
(MM% &
instanceMM& .
,MM. /
convertedValueMM0 >
)MM> ?
;MM? @
returnNN 
;NN 
}OO 
throwQQ 
newQQ 
ImporterExceptionQQ '
(QQ' (
$"QQ( *
$strQQ* >
{QQ> ?
propertyInfoQQ? K
.QQK L
NameQQL P
}QQP Q
$strQQQ k
"QQk l
)QQl m
;QQm n
}RR 	
publicTT 
staticTT 
voidTT "
SetGuidValueFromStringTT 1
(TT1 2
thisTT2 6
PropertyInfoTT7 C
propertyInfoTTD P
,TTP Q
objectTTR X
instanceTTY a
,TTa b
stringTTc i
valueTTj o
)TTo p
{UU 	
ifVV 
(VV 
GuidVV 
.VV 
TryParseVV 
(VV 
valueVV #
,VV# $
outVV% (
_VV) *
)VV* +
)VV+ ,
{WW 
varXX 
convertedValueXX "
=XX# $
GuidXX% )
.XX) *
ParseXX* /
(XX/ 0
valueXX0 5
)XX5 6
;XX6 7
propertyInfoYY 
.YY 
SetValueYY %
(YY% &
instanceYY& .
,YY. /
convertedValueYY0 >
)YY> ?
;YY? @
returnZZ 
;ZZ 
}[[ 
throw]] 
new]] 
ImporterException]] '
(]]' (
$"]]( *
$str]]* >
{]]> ?
propertyInfo]]? K
.]]K L
Name]]L P
}]]P Q
$str]]Q g
"]]g h
)]]h i
;]]i j
}^^ 	
}__ 
}`` ü
qC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\GenericImporter.Service\Extensions\TypeExtensions.cs
	namespace 	
GenericImporter
 
. 
Service !
.! "

Extensions" ,
{		 
public

 

static

 
class

 
TypeExtensions

 &
{ 
public 
static 
PropertyInfo "#
GetPropertyByImportName# :
(: ;
this; ?
Type@ D
typeE I
,I J
stringK Q
nameR V
)V W
{ 	
var 
foundedProperties !
=" #
new$ '
List( ,
<, -
PropertyInfo- 9
>9 :
(: ;
); <
;< =
foreach 
( 
var 
property !
in" $
type% )
.) *
GetProperties* 7
(7 8
)8 9
)9 :
{ 
var 
	attribute 
= 
property  (
.( )
GetImportAttribute) ;
(; <
)< =
;= >
if 
( 
	attribute 
!=  
null! %
&&& (
	attribute) 2
.2 3
Name3 7
==8 :
name; ?
)? @
{ 
foundedProperties %
.% &
Add& )
() *
property* 2
)2 3
;3 4
} 
} 
if 
( 
foundedProperties !
.! "
Count" '
>( )
$num* +
)+ ,
{ 
throw 
new 
ImporterException +
(+ ,
$str, [
)[ \
;\ ]
} 
return 
foundedProperties $
.$ %
SingleOrDefault% 4
(4 5
)5 6
;6 7
} 	
public!! 
static!!  
ImportClassAttribute!! *#
GetImportClassAttribute!!+ B
(!!B C
this!!C G
Type!!H L
type!!M Q
)!!Q R
{"" 	
var## 
customAttribute## 
=##  !
type##" &
.##& '
GetCustomAttributes##' :
(##: ;
typeof##; A
(##A B 
ImportClassAttribute##B V
)##V W
,##W X
false##Y ^
)##^ _
.##_ `
SingleOrDefault##` o
(##o p
)##p q
;##q r
if%% 
(%% 
customAttribute%% 
!=%%  "
null%%# '
)%%' (
{&& 
return'' 
(''  
ImportClassAttribute'' ,
)'', -
customAttribute''- <
;''< =
}(( 
return** 
null** 
;** 
}++ 	
public-- 
static-- 
object-- 
CreateInstance-- +
(--+ ,
this--, 0
Type--1 5
type--6 :
)--: ;
{.. 	
return// 
	Activator// 
.// 
CreateInstance// +
(//+ ,
type//, 0
)//0 1
;//1 2
}00 	
public22 
static22 

MethodInfo22   
GetMethodOfInterface22! 5
(225 6
this226 :
Type22; ?
type22@ D
,22D E
string22F L
name22M Q
)22Q R
{33 	
return44 
type44 
.44 
	GetMethod44 !
(44! "
name44" &
,44& '
BindingFlags44( 4
.444 5
Public445 ;
|44< =
BindingFlags44> J
.44J K
FlattenHierarchy44K [
|44\ ]
BindingFlags44^ j
.44j k
Instance44k s
)44s t
;44t u
}55 	
}66 
}77 