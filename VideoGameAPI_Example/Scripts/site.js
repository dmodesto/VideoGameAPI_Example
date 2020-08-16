$(document).ready(function () {
    // show and hide Summary
    $('#games').on('click', '.dots', function () {
        var self = this;
        $(self).addClass('hidden');
        $(self).parent().children('.more').removeClass('hidden');
    });

    $('#games').on('click', '.less', function () {
        var self = this;
        $(self).parent().parent().children('.dots').removeClass('hidden');
        $(self).parent().addClass('hidden');
    });
})

function getGames(genreList, platformList, apiUrl, dataObj) {

    // hide datatable errors from the user
    $.fn.dataTable.ext.errMode = 'none';

    // send missing data errors to the console
    $('#games').on('error.dt', function (e, settings, techNote, message) {
        console.log('An error has been reported by DataTables: ', message);
    }).DataTable(
        {
            ajax: {
                type: "POST",
                url: apiUrl,
                data: dataObj,
                dataSrc: ""
            },
            columns: [
                {
                    data: "name",
                    render: function (data, type, row) {
                        return "<a href='../Game/" + row.id + "'>" + data + "</a>";
                    }
                },
                {
                    data: "genres",  // provide the genre name based on the model.genres.Name
                    render: function (data) {
                        var genreText = "";

                        genreList.forEach(function (genre) {

                            if (!data) return;

                            if (data.includes(genre.Id)) {
                                genreText += genre.Name + ", ";
                            }
                        })

                        // remove the last comma and space
                        if (genreText.length > 0) {
                            genreText = genreText.substr(0, genreText.length - 2);
                        }

                        return "<span>" + genreText + "</span>";
                    }
                },
                {
                    data: "platforms",  // provide the platform name based on the model.platforms.name
                    render: function (data) {
                        var platformText = "";

                        platformList.forEach(function (platform) {

                            if (!data) return;

                            if (data.includes(platform.Id)) {
                                platformText += platform.Name + ", ";
                            }
                        })

                        // remove the last comma and space
                        if (platformText.length > 0) {
                            platformText = platformText.substr(0, platformText.length - 2);
                        }

                        $("#platformTitle").html(platformText);

                        return "<span>" + platformText + "</span>";
                    }
                },
                {
                    data: "summary",
                    render: function (data) {
                        if (data) {
                            return data.substring(0, 100) +
                                "<button class='btn btn-link dots' " +
                                ">...[more]</button><span class='more hidden'>" +
                                data.substring(100, data.length) +
                                "<button class='btn btn-link less'>...[less]</button></span>";
                        }
                        else {
                            return "Description not available.";
                        }
                    }
                },
                {
                    data: "total_rating",
                    render: function (data) {
                        if (data)
                            return data.toFixed(2);
                        else
                            return;
                    }
                }
            ],
            order: [[4, "desc"]]
        });

    //used to test /api/topgames, and view json results
    //$("#games").on("click", ".js-ajax", function () {
    //    $.ajax({
    //        url: "/Api/Search/",
    //        method: "GET"
    //    }).done(function (response) {
    //        console.log(response);
    //    });
    //});

}