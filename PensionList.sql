ALTER PROCEDURE [PensionList](
    @agencyId INT
)
AS
BEGIN

--DECLARE @agencyId INT = 1;

SELECT
ag.ShortName,
aa.BadgeId,
a.LastName + ' ' + a.FirstName NameLastFirst,
a.DateOfBirth,
aa.DeactivationDate
FROM AgencyAgent aa
    JOIN Agency ag ON ag.AgencyId = aa.AgencyId
    JOIN Agent a ON aa.AgentId = a.AgentId
    JOIN SecurityClearance sc ON aa.SecurityClearanceId = sc.SecurityClearanceId
WHERE sc.SecurityClearanceName = 'retired'
    AND ag.AgencyId = @agencyId

END