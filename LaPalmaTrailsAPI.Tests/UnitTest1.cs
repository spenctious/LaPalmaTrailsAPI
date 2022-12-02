namespace LaPalmaTrailsAPI.Tests
{
    public class StatusScraperTests
    {

        private StatusScraper CreateStatusScraper(string testPage)
        {
            StatusScraper scraper = new();
            scraper.StatusPage = testPage;
            scraper.ClearLookups = true;
            scraper.UseCache = false;

            return scraper;
        }


        [Fact]
        public async Task Invalid_status_table_creates_data_error()
        {
            StatusScraper sut = CreateStatusScraper("Invalid_Table.html");

            var scraperResult = await sut.GetTrailStatuses(new MockWebReader());

            Assert.Equal(ScraperEvent.EventType.DataError.ToString(), scraperResult.Result.Type);
            Assert.Empty(scraperResult.Trails);
            Assert.Empty(scraperResult.Anomalies);

            Assert.Equal(ScraperEvent.EventType.DataError.ToString(), scraperResult.Result.Type);
            Assert.Equal("Trail network probably closed",               scraperResult.Result.Message);
            Assert.Equal("Missing table with id tablepress-14", scraperResult.Result.Detail);
        }


        [Fact]
        public async Task Valid_trail_scraped_creates_trail_and_success_result()
        {
            Assert.False(true);
        }


        [Fact]
        public async Task Invalid_trail_id_results_in_anomaly()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Valid_trail_with_extra_zero_after_decimal_point_is_corrected()
        {
            Assert.False(true);
        }


        [Fact]
        public async Task Bad_trail_URL_creates_anomaly()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Zip_and_PDF_links_creates_anomaly()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Part_open_status_links_to_status_page()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Uncertain_status_creates_anomaly()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Additinal_link_updates_lookup_table_on_file()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Timeout_reading_status_page_creates_timeout_result()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Exception_reading_status_page_creates_exception_result()
        {
            Assert.False(true);
        }

        // links

        [Fact]
        public async Task English_URL_not_in_map_gets_added()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task English_URL_in_map_gets_returned()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task English_URL_not_found_creates_anomaly()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Timeout_reading_detail_page_creates_anomaly()
        {
            Assert.False(true);
        }

        [Fact]
        public async Task Exception_reading_detail_page_creates_anomaly()
        {
            Assert.False(true);
        }
    }
}