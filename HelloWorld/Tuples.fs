module Tuples

let hodgepodge = ("xkcd", 3.142, System.Math.PI, 0xFFFFFF,"the oatmeal");;

let morehodgepodge = (System.Math.PI * System.Math.E, "Path not found.  Try the grass shortcut",("Hello","World"), printfn "I come first!");;

let circumference (x:float, y:float, z:float) = (2.0 * System.Math.PI * x, 2.0 * System.Math.PI * y, 2.0 * System.Math.PI * z);;

type MacOSRelease =
    { Title: string;
      Version : string }

let beta = {Title="Kodiak"; Version="Beta"};;
let v10_0 = {Title="Cheetah"; Version="10.0"};;
let V10_1  = {Title="Puma"; Version="10.1"};;
let v10_2 = {Title="Jaguar"; Version="10.2"};;
let v10_3 = {Title="Panther"; Version="10.3"};;
let v10_4 = {Title="Tiger"; Version="10.4"};;
let v10_5 = {Title="Leopard"; Version="10.5"};;
let v10_6 = {Title="Snow Leopard"; Version="10.6"};;
let v10_7 = {Title="Lion"; Version="10.7"};;
let v10_8 = {Title="Mountain Lion"; Version="10.8"};;
let v10_9 = {Title="Mavericks"; Version="10.9"};;
let v10_10 = {Title="Yosemite"; Version="10.10"};;


let isEven (n : int) = if n %  2 = 0 then Some(n) else None

