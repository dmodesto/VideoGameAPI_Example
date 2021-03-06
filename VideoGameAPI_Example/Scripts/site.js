﻿$(document).ready(function () {
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
            responsive: true,
            columnDefs: [
                { responsivePriority: 1, targets: 0, className: "text-center" },
                { responsivePriority: 2, targets: 4 },
                { responsivePriority: 3, targets: 3, width: "40%" },
                { responsivePriority: 4, targets: 1 }
            ],
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
                        // get a larger image by pulling the 'cover_big' url
                        var imageSrc = '';
                        try {
                            imageSrc = row.cover.url;
                            imageSrc = String(imageSrc).replace("t_thumb", "t_cover_small");
                            return "<a href='../Game/" + row.id + "'>" +
                                "<img src='" + imageSrc + "'>" +
                                "<br />" + data + "</a>";
                        }
                        catch (e) {
                            return "<a href='../Game/" + row.id + "'>" + data + "</a>";
                        }
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

                        return "<span>" + platformText + "</span>";
                    }
                },
                {
                    data: "summary",
                    render: function (data) {
                        if (data) {
                            //return data;
                            return data.substring(0, 400) +
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

    // catch errors
    $.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
        console.log(message);
    };

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