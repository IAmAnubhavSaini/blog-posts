(function (startIndex, endIndex) {

    var Start = startIndex,
        End = endIndex,

        Rule = function (forNumber, sayThis) {
            this.Number = forNumber
            this.Say = sayThis
        },

        Rules = [
            new Rule(3, "fizz"),
            new Rule(5, "buzz")
        ],

        Say = function (number) {
            var toSay = '';
            for (var i = 0; i < Rules.length; i++) {
                if (number % Rules[i].Number === 0) {
                    toSay += Rules[i].Say;
                }
            }
            return toSay.length > 0 ? toSay : number;
        },

        output = function (message) {
            console.log(message);
        },

        FizzBuzz = function () {
            for (var i = Start; i < End; i++) {
                output(Say(i));
            }
        };

    FizzBuzz();

})(1, 20);