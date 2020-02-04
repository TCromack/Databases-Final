$(document).ready(function () {
    $("#filter").change(function () {
        var tag = $(this).val();
        console.log(tag)
        if (tag == "ALL") {
            $("#playerTable").find("tr.playerRow").each(function () {
                $(this).show();
            });
        }
        else {
            $("#playerTable").find("tr.playerRow").each(function () { 
                var self = $(this);
                console.log(self.children().first());
               
                if (self.children().first().text().trim() == tag) {
                    self.show();
                }
                else {
                    self.hide();
                }

            });

        }

    });

    $("#playerSearch").on("input",function () {
        var tag = $(this).val().toLowerCase();
        console.log("searching")
        if (tag.length == 0) {
            $("#playerTable").find("tr.playerRow").each(function () {
                $(this).show();
            });
        }
        else {
            $("#playerTable").find("tr.playerRow").each(function () {
                var self = $(this);
                console.log(self.children().first());

                if (self.children(".playerFirstName").first().text().trim().toLowerCase().startsWith(tag) || self.children(".playerLastName").first().text().trim().toLowerCase().startsWith(tag) ) {
                    self.show();
                }
                else {
                    self.hide();
                }

            });

        }
    })
});