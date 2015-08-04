module SetsMaps

let androidVersions = Set.empty.Add("Cupcake").Add("Donut").Add("Eclair").Add("Froyo").Add("Gingerbread").Add("Honeycomb").Add("Ice Cream Sandwich").Add("Jelly Bean").Add("KitKat")

androidVersions.Add ("Lollipop")

let bibTeXBiblio = Map.empty.Add("agrawal1996fast", "Fast Discovery of Association Rules.")
                            .Add("bell2009beyond", "Beyond the data deluge")
                            .Add("Wooldridge2003", "Bayesian Belief Networks")
                            .Add("Witten2005", "Data Mining: Practical machine learning tools and techniques");;
 
 bibTeXBiblio.["Wooldridge2003"]


type Title = string  
type Rating = string
type Plot = string  
type Ranking = float
type Year = int

type Movie = Movie of Title * Rating * Plot * Ranking * Year

let Serenity = Movie("Serenity", "PG-13", "The crew of the ship Serenity tries to evade an assassin sent to recapture one of their number who is telepathic.", 8.0, 2005)


type Human = {first:string; last:string}

type IntelligentBeing = 
  | Robot of float * int //model and year
  | H of Human 

let unit1  = Robot (8.5, 2051)
let unit2  = H {first="Stephen"; last="Hawking"} 


let (|Even|Odd|) x = if x % 2 <> 0 then Odd else Even


//let (|ToServiceObject|) x =
//    match x with
//    | "NServiceBus"   -> NServiceBus.Instance
//    | "MuleESB"  -> MuleESB.Instance
//    | "RabbitMQ" -> RabbitMQ.Instance
//    | _       -> failwith "Unknown Object"
// let (ToServiceObject object) = "RabbitMQ"