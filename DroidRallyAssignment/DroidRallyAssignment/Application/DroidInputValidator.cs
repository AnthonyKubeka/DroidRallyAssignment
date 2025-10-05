namespace DroidRallyAssignment.Application
{
    public static class DroidInputValidator
    {
        public static bool IsValidGridDimensions(string? gridDimensions)
        {
            if (string.IsNullOrWhiteSpace(gridDimensions))
            {
                return false;
            }

            var dimensions = gridDimensions.Split(' ');
            if (dimensions.Length != 2)
            {
                return false;
            }

            if (!int.TryParse(dimensions[0], out int x) || !int.TryParse(dimensions[1], out int y))
            {
                return false;
            }

            if (x <= 0 || y <= 0)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidDroidInput(string? droidInput)
        {
            if (string.IsNullOrWhiteSpace(droidInput))
            {
                return false;
            }

            var inputs = droidInput.Split(' ');

            if (inputs.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(inputs[0], out int x) || !int.TryParse(inputs[1], out int y))
            {
                return false;
            }

            if (x < 0 || y < 0)
            {
                return false;
            }

            return EnumMapper.TryParseDirection(inputs[2], out _);
        }
    }
}
