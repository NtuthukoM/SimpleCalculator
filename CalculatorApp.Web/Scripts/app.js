function SendToServer(_verb, _url, _data) {
    var options = {
        url: _url,
        contentType: "application/json; charset=utf-8",
        type: _verb,
        data: _data
    };
    var ajax1 = $.ajax(options);
    return ajax1;
}

function CalculatorVM() {
    var self = this;
    self.DisplayText = ko.observable('0');
    self.CanCompute = ko.observable(false);
    self.Num1 = '0';
    self.Num2 = '';
    self.Answer = '';
    self.CalcOpp = '';

    self.Negate = function () {
        var display = '';
        if (self.CalcOpp == '') {
            if (self.Num1.length == 0) return;
            var num = parseInt(self.Num1);
            if (num == 0) return;
            if (num < 0) {
                self.Num1 = self.Num1.substr(1, self.Num1.length - 1);
            } else {
                self.Num1 = "-" + self.Num1;
            }

            display = self.Num1;

        } else {
            if (self.Num2.length == 0) return;
            var num = parseInt(self.Num2);
            if (num == 0) return;
            if (num < 0) {
                self.Num2 = self.Num2.substr(1, self.Num2.length - 1);
            } else {
                self.Num2 = "-" + self.Num2;
            }

            display = self.Num1 + " "
                + self.CalcOpp + " " + self.Num2;
            self.CanCompute(true);
        }
        self.DisplayText(display);
    }

    self.Clear = function () {
        if (self.Num2.length > 0) {
            self.Num2 = '';
            var display = self.Num1 + " "
                + self.CalcOpp + " " + self.Num2;
            self.DisplayText(display);
        } else {
            self.ClearAll();
        }
    }

    self.ClearAll = function () {
        self.DisplayText('0');
        self.Num1 = '0';
        self.Num2 = '';
        self.Answer = '';
        self.CalcOpp = '';
        self.CanCompute(false);
    }

    self.BackSpace = function () {
        var display = '';
        if (self.CalcOpp == '') {
            if (self.Num1.length == 0) return;
            self.Num1 = self.Num1.substr(0, self.Num1.length - 1);
            if (self.Num1.length == 0) self.Num1 = "0";
            display = self.Num1;
        } else if (self.Num2.length > 0) {
            self.Num2 = self.Num2.substr(0, self.Num2.length - 1);
            display = self.Num1 + " "
                + self.CalcOpp + " " + self.Num2;
            self.CanCompute(true);
        } else {
            self.CalcOpp = '';
            display = self.Num1;
        }
        self.DisplayText(display);
    }

    self.SetOpp = function (m, e) {
        self.CalcOpp = e.target.innerText;
        var display = self.Num1 + " "
                + self.CalcOpp;
        self.DisplayText(display);
    }

    self.UpdateNum = function (m, e) {
        var text = e.target.innerText;
        var display = '';
        if (self.CalcOpp == '') {
            if (self.Num1 == '0')
                self.Num1 = text;
            else
                self.Num1 += text;
            display = self.Num1;

        } else {
            self.Num2 += text;
            display = self.Num1 + " "
                + self.CalcOpp + " " + self.Num2;
            self.CanCompute(true);
        }
        self.DisplayText(display);
    }

    self.AddPeriod = function (m, e) {
        var text = e.target.innerText;
        var display = '';
        if (self.CalcOpp == '') {
            if (self.Num1.indexOf(".") > -1) return;
            if (self.Num1.length == 0)
                self.Num1 = "0";
            self.Num1 += text;
            display = self.Num1;

        } else {
            if (self.Num2.indexOf(".") > -1) return;
            if (self.Num2.length == 0)
                self.Num2 = "0";
            self.Num2 += text;
            display = self.Num1 + " "
                + self.CalcOpp + " " + self.Num2;
            self.CanCompute(true);
        }
        self.DisplayText(display);
    }

    self.Calculate = function () {
        var m = ko.toJS(self);
        delete m.Calculate;
        delete m.UpdateNum;

        SendToServer('POST', '/Home/Calculate', JSON.stringify(m))
        .then(function (data) {
            self.DisplayText(data.Answer);
            if (data.Answer != 'Cannot divide by 0.' && data.Answer != 'Infinity')
                self.Num1 = data.Answer;
            else
                self.Num1 = '0';
            self.Num2 = '';
            self.Answer = '';
            self.CalcOpp = '';
            self.CanCompute(false);
        });
    }

}
var vm = new CalculatorVM();
ko.applyBindings(vm);

$(".calc-frame").draggable({
    stop: function () {
        var element = $(this);
        element.removeClass('animated tada');
        var animation = 'swing';
        element.addClass('animated ' + animation);
        //wait for animation to finish before removing classes 
        window.setTimeout(function () {
            element.removeClass('animated ' + animation);
        }, 2000);
    }
});