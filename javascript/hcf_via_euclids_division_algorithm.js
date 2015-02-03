HCF = function(number1, number2){
	var calculate = function(){
		var a = number1 > number2 ? number1 : number2,
		b = number1 > number2 ? number2 : number1;

		if(a > 0 && b > 0){
			var q = parseInt(a/b),
			r = parseInt(a%b);
			while(r > 1){
				a = b;
				b = r;
				q = parseInt(a/b),
				r = parseInt(a%b);
			}
			if(r === 0) return b;
			else if(r === 1) return 1;
		}
		return -1;
	};

	return {
		calculate: calculate
	};
};

(new HCF(26, 7)).calculate()
(new HCF(21, 7)).calculate()
(new HCF(20, 7)).calculate()
(new HCF(22, 7)).calculate()
(new HCF(7, 7)).calculate()