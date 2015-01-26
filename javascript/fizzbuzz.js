(function () {
    function output(message) {
        console.log(message);
    }

    function FizzBuzz() {
        for (var i = 1; i < 20; i++) {
            if (i % 15 === 0)
                output("fizzbuzz")
            else if (i % 5 === 0)
                output("buzz")
            else if (i % 3 === 0)
                output("fizz")
            else
                output(i);
        }
    }

    FizzBuzz();
})();